using CodePractice.Data.Models;

namespace CodePractice.Data.Interfaces
{
    public interface ICompetenciesRepo
    {
        Task<IEnumerable<Competency>> GetCompetenciesAsync(int page, int number);
        Task<Competency?> GetCompetencyAsync(int id);
        Task<Competency?> UpdateCompetencyAsync(Competency competency);
        Task<Competency> AddCompetencyAsync(Competency competency);
        bool DeleteCompetencyAsync(int id);
    }
}