using CodePractice.Shared.Interfaces;
using CodePractice.Shared.Models;

namespace CodePractice.Server.Data.Repos
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
            Competency? competency = _context.Competencies.Where(e => e.Id == id).FirstOrDefault();
            return competency;
        }

        public List<Competency> GetCompetencies()
        {
            return _context.Competencies.ToList();
        }

        public List<Competency> GetCompetencies(int page, int number)
        {
            return _context.Competencies.Skip((page - 1) * number).Take(number).ToList();
        }

        public Competency AddCompetency(Competency competency)
        {
            _context.Competencies.Add(competency);
            _context.SaveChanges();
            return competency;
        }

        public Competency? UpdateCompetency(Competency competency)
        {
            var competencyToUpdate = _context.Competencies.Where(e => e.Id == competency.Id).FirstOrDefault();
            if (competencyToUpdate != null)
            {
                competencyToUpdate.Title = competency.Title;
                competencyToUpdate.Description = competency.Description;
                competencyToUpdate.FirstExerciseId = competency.FirstExerciseId;
                competencyToUpdate.LastExerciseId = competency.LastExerciseId;
                _context.Competencies.Update(competencyToUpdate);
            }
            _context.SaveChanges();
            return competencyToUpdate;
        }

        public bool DeleteCompetency(int id)
        {
            var competencyToDelete = _context.Competencies.Where(e => e.Id == id).FirstOrDefault();
            if (competencyToDelete != null)
            {
                //TODO: Remove exercises from competency
                _context.Competencies.Remove(competencyToDelete);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Exercise GetFirstExercise(int id)
        {
            var competency = _context.Competencies.Where(e => e.Id == id).FirstOrDefault();
            if (competency != null)
            {
                var exercise = _context.Exercises.Where(e => e.Id == competency.FirstExerciseId).FirstOrDefault();
                return exercise;
            }
            else
            {
                return null;
            }
        }
    }
}
