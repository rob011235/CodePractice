using CodePractice.Data.Models;

namespace CodePractice.Data.Interfaces
{
    public interface IExerciseRepo
    {
        Exercise AddExercise(Exercise exercise, int competencyId);
        bool DeleteExercise(int id);
        Exercise? GetExercise(int id);
        List<Exercise> GetExercises(int page, int number);
        Exercise? UpdateExercise(Exercise exercise);
        public int GetHighestOrderIndex(Competency competency);
    }
}