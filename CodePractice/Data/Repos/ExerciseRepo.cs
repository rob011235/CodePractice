using CodePractice.Data.Interfaces;
using CodePractice.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodePractice.Data.Repos
{
    public class ExerciseRepo : IExercisesRepo
    {
        private readonly ApplicationDbContext _context;
        public ExerciseRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public Exercise? GetExercise(int id)
        {
            return _context.Exercises.Where(e => e.Id == id).FirstOrDefault();
        }

        public List<Exercise> GetExercises(int page, int pageSize)
        {
            return _context.Exercises.Include(e=>e.Competency).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public Exercise AddExercise(Exercise exercise)
        {
            var returnExercise = _context.Exercises.Add(exercise);
            var competencyToUpdate = _context.Competencies.Where(e => e.Id == returnExercise.Entity.CompetencyId).FirstOrDefault();

            if (competencyToUpdate != null)
            {
                Exercise lastExercise = _context.Exercises.Where(e => e.Id == competencyToUpdate.LastExerciseId).FirstOrDefault();

                if (lastExercise != null)
                {
                    lastExercise.NextExerciseId = returnExercise.Entity.Id;
                }
                else
                {
                    competencyToUpdate.FirstExerciseId = returnExercise.Entity.Id;
                }
                //TODO: Make sure returnExercise.Entity.Id is not null
            }
            _context.SaveChanges();
            return returnExercise.Entity;
        }

        public Exercise? UpdateExercise(Exercise exercise)
        {
            var exerciseToUpdate = _context.Exercises.Where(e => e.Id == exercise.Id).FirstOrDefault();
            if (exerciseToUpdate != null)
            {
                Competency? previousCompetency = _context.Competencies.Where(c=>c.Id==exerciseToUpdate.CompetencyId).FirstOrDefault();
                exerciseToUpdate.Title = exercise.Title;
                exerciseToUpdate.Question = exercise.Question;
                exerciseToUpdate.DesiredOutput = exercise.DesiredOutput;
                exerciseToUpdate.Answer = exercise.Answer;
                exerciseToUpdate.Hint = exercise.Hint;
                if (exerciseToUpdate.CompetencyId != exercise.CompetencyId)
                {
                    //Is this the first exercise in the competency?
                    if (exerciseToUpdate.PreviousExerciseId == null)
                    {
                        //Set new competency's first exercise to this exercise's next exercise
                        previousCompetency.FirstExerciseId = exerciseToUpdate.NextExerciseId;
                    }
                    else //This is not the first exercise in the competency
                    {
                        //Set previous exercise's next exercise to this exercise's next exercise
                        Exercise previousExercise = _context.Exercises.Where(e => e.Id == exerciseToUpdate.PreviousExerciseId).FirstOrDefault();
                        if (previousExercise != null)
                        {
                            previousExercise.NextExerciseId = exerciseToUpdate.NextExerciseId;
                        }
                        
                    }
                    //Set new competency
                    exerciseToUpdate.CompetencyId = exercise.CompetencyId;
                    //place new exercise at end of new competency
                    Competency? newCompetency = _context.Competencies.Where(c => c.Id == exercise.CompetencyId).FirstOrDefault();
                    Exercise? lastExercise = _context.Exercises.Where(e => e.Id == newCompetency.LastExerciseId).FirstOrDefault();
                    lastExercise.NextExerciseId = exerciseToUpdate.Id;
                    newCompetency.LastExerciseId = exerciseToUpdate.Id;
                }
            }
            _context.SaveChanges();
            return exerciseToUpdate;
        }

        public bool DeleteExercise(int id)
        {
            var exerciseToDelete = _context.Exercises.Where(e => e.Id == id).FirstOrDefault();
            if (exerciseToDelete == null)
            {
                return false;
            }
            //Reorder exercises in competency
            if (exerciseToDelete.PreviousExerciseId == null)
            {
                Competency? competencyToUpdate = _context.Competencies.Where(c => c.Id == exerciseToDelete.CompetencyId).FirstOrDefault();
                competencyToUpdate.FirstExerciseId = exerciseToDelete.NextExerciseId;
            }
            else
            {
                Exercise ? previousExercise = _context.Exercises.Where(e => e.Id == exerciseToDelete.PreviousExerciseId).FirstOrDefault();
                previousExercise.NextExerciseId = exerciseToDelete.NextExerciseId;
            }
            _context.Exercises.Remove(exerciseToDelete);
            _context.SaveChanges();
            return true;
        }

        //Get next exercise
        public Exercise? GetNextExercise(Exercise exercise)
        {
            if (exercise == null)
            {
                return null;
            }
            return _context.Exercises.Where(e => e.Id == exercise.NextExerciseId).FirstOrDefault();
        }

        //Get exercise by competency
        public List<Exercise> GetExercisesByCompetency(int competencyId, int page, int pageSize)
        {
            return _context.Exercises.Where(e=>e.CompetencyId == competencyId).Include(e => e.Competency).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
