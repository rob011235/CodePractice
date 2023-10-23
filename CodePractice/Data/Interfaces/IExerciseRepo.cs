using CodePractice.Data.Models;

namespace CodePractice.Data.Interfaces
{
    public interface IExerciseRepo
    {
        Task<Exercise> AddExerciseAsync(Exercise exercise);
        bool DeleteExerciseAsync(int id);
        Task<Exercise?> GetExerciseAsync(int id);
        Task<IEnumerable<Exercise>> GetExercisesAsync(int page, int number);
        Task<Exercise?> UpdateExerciseAsync(Exercise exercise);
    }
}