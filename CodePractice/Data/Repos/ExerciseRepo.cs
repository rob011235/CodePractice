using CodePractice.Data.Interfaces;
using CodePractice.Data.Models;

namespace CodePractice.Data.Repos
{
    public class ExerciseRepo : IExerciseRepo
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

        public List<Exercise> GetExercises(int page, int number)
        {
            return _context.Exercises.Skip((page - 1) * number).Take(number).ToList();
        }

        public Exercise? GetNextExercise(Exercise exercise)
        {
            return exercise.Competency.Exercises.Where(e => e.OrderIndex == exercise.OrderIndex + 1).FirstOrDefault();
        }

        public Exercise AddExercise(Exercise exercise, int competencyId)
        {

            var returnExercise = _context.Exercises.Add(exercise);
            var competencyToUpdate = _context.Competencies.Where(e => e.Id == competencyId).FirstOrDefault();
            if(competencyToUpdate != null)
            {
                returnExercise.Entity.OrderIndex = GetHighestOrderIndex(competencyToUpdate) + 1;
                competencyToUpdate.Exercises.Add(returnExercise.Entity);
            }
            _context.SaveChanges();
            return returnExercise.Entity;
        }

        public int GetHighestOrderIndex(Competency competency)
        {
            return competency.Exercises?.Max(e => e.OrderIndex) ?? 0;
        }

        public Exercise? UpdateExercise(Exercise exercise)
        {
            var exerciseToUpdate = _context.Exercises.Where(e => e.Id == exercise.Id).FirstOrDefault();
            if (exerciseToUpdate != null)
            {
                exerciseToUpdate.Title = exercise.Title;
                exerciseToUpdate.Question = exercise.Question;
                exerciseToUpdate.DesiredOutput = exercise.DesiredOutput;
                exerciseToUpdate.Answer = exercise.Answer;
                exerciseToUpdate.Hint = exercise.Hint;
                if(exerciseToUpdate.CompetencyId != exercise.CompetencyId)
                {
                    //Remove exercise from old competency
                    var oldCompetency = _context.Competencies.Where(c => c.Id == exerciseToUpdate.CompetencyId).FirstOrDefault();
                    if(oldCompetency != null)
                    {
                        oldCompetency.Exercises.Remove(exerciseToUpdate);
                        //Reorder exercises in old competency
                        foreach(var e in oldCompetency.Exercises)
                        {
                            if(e.OrderIndex > exerciseToUpdate.OrderIndex)
                            {
                                e.OrderIndex--;
                            }
                        }
                    }
                    //Add exercise to new competency
                    var newCompetency = _context.Competencies.Where(c => c.Id == exercise.CompetencyId).FirstOrDefault();
                    if(newCompetency != null)
                    {
                        newCompetency.Exercises.Add(exerciseToUpdate);
                        //Reorder exercises in new competency
                        foreach(var e in newCompetency.Exercises)
                        {
                            if(e.OrderIndex >= exercise.OrderIndex)
                            {
                                e.OrderIndex++;
                            }
                        }
                    }
                }
                exerciseToUpdate.CompetencyId = exercise.CompetencyId;
                exerciseToUpdate.OrderIndex = exercise.OrderIndex;  
            }
            _context.SaveChanges();
            return exerciseToUpdate;
        }

        public bool DeleteExercise(int id)
        {
            var exerciseToDelete = _context.Exercises.Where(e => e.Id == id).FirstOrDefault();
            //Remove exercise from competency
            var competencyToUpdate = _context.Competencies.Where(c => c.Id == exerciseToDelete.CompetencyId).FirstOrDefault();
            if(competencyToUpdate != null)
            {
                competencyToUpdate.Exercises.Remove(exerciseToDelete);
                //Reorder exercises in competency
                foreach(var e in competencyToUpdate.Exercises)
                {
                    if(e.OrderIndex > exerciseToDelete.OrderIndex)
                    {
                        e.OrderIndex--;
                    }
                }
            }
            if (exerciseToDelete != null)
            {
                _context.Exercises.Remove(exerciseToDelete);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
