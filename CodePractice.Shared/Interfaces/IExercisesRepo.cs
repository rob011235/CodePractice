using CodePractice.Shared.Models;

namespace CodePractice.Shared.Interfaces
{
    public interface IExercisesRepo
    {
        Exercise AddExercise(Exercise exercise);
        bool DeleteExercise(int id);
        Exercise? GetExercise(int id);
        List<Exercise> GetExercises(int page, int number);
        Exercise? UpdateExercise(Exercise exercise);
        //public Exercise? GetNextExercise(Exercise exercise);
        public List<Exercise> GetExercisesByCompetency(int competencyId, int page, int pageSize);
    }
}