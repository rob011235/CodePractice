using CodePractice.Data.Interfaces;
using CodePractice.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CodePractice.Data.Repos
{
    public class CompetenciesRepo : ICompetenciesRepo
    {      
        private readonly ApplicationDbContext _context;
        public CompetenciesRepo(ApplicationDbContext context)
        {
            _context = context; 
        }

        public Competency? GetCompetency(int id)
        {
            Competency? competency = _context.Competencies.Where(e => e.Id == id).Include(c=>c.Exercises).FirstOrDefault();
            return competency;
        }

        public List<Competency> GetCompetencies(int page, int number)
        {
            return _context.Competencies.Skip((page - 1) * number).Take(number).Include(c=>c.Exercises).ToList();
        }

        public Competency AddCompetency(Competency competency)
        {
            _context.Competencies.Add(competency);
            _context.SaveChanges();
            return competency;
        }

        public Competency? UpdateCompetency(Competency competency)
        {
            var competencyToUpdate = _context.Competencies.Where(e => e.Id == competency.Id).Include(c=>c.Exercises).FirstOrDefault();
            if (competencyToUpdate != null)
            {
                competencyToUpdate.Title = competency.Title;
                competencyToUpdate.Description = competency.Description;
                competencyToUpdate.Exercises = competency.Exercises;
            }
            _context.SaveChanges();
            return competencyToUpdate;
        }

        public bool DeleteCompetency(int id)
        {
            var exerciseToDelete = _context.Competencies.Where(e => e.Id == id).FirstOrDefault();
            if (exerciseToDelete != null)
            {
                _context.Competencies.Remove(exerciseToDelete);
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
