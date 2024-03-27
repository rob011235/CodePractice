using CodePractice.Shared.Models;

namespace CodePractice.Shared.Interfaces
{
    public interface ICompetenciesRepo
    {
        public List<Competency> GetCompetencies();
        List<Competency> GetCompetencies(int page, int number);
        Competency? GetCompetency(int id);
        Competency? UpdateCompetency(Competency competency);
        Competency AddCompetency(Competency competency);
        bool DeleteCompetency(int id);
        Exercise? GetNextExercise(Competency competency, ApplicationUser user);
        Task<List<Submission>> GetUserExerciseSubmissionsAsync(Competency competency, ApplicationUser user);
    }
}