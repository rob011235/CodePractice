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

        public Exercise AddExercise(Exercise exercise, int competencyId)
        {
            var returnExercise = _context.Exercises.Add(exercise);
            var competencyToUpdate = _context.Competencies.Where(e => e.Id == competencyId).FirstOrDefault();
            if(competencyToUpdate != null)
            {
                competencyToUpdate.Exercises.Add(returnExercise.Entity);
            }
             _context.SaveChanges();
            return returnExercise.Entity;
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
            }
            _context.SaveChanges();
            return exerciseToUpdate;
        }

        public bool DeleteExercise(int id)
        {
            var exerciseToDelete = _context.Exercises.Where(e => e.Id == id).FirstOrDefault();
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
