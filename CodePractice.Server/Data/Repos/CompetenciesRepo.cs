using CodePractice.Shared.Interfaces;
using CodePractice.Shared.Models;
using Microsoft.EntityFrameworkCore;

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
            Competency? competency = _context.Competencies.Include(c=>c.Exercises).Where(e => e.Id == id).Include(c => c.Exercises).FirstOrDefault();
            return competency;
        }

        public List<Competency> GetCompetencies()
        {
            return _context.Competencies.Include(c => c.Exercises).ToList();
        }

        public List<Competency> GetCompetencies(int page, int number)
        {
            return _context.Competencies.Include(c => c.Exercises).Skip((page - 1) * number).Take(number).ToList();
        }

        public Competency AddCompetency(Competency competency)
        {
            _context.Competencies.Add(competency);
            _context.SaveChanges();
            return competency;
        }

        public Competency? UpdateCompetency(Competency competency)
        {
            var competencyToUpdate = _context.Competencies.Include(c => c.Exercises).Where(e => e.Id == competency.Id).FirstOrDefault();
            if (competencyToUpdate != null)
            {
                competencyToUpdate.Title = competency.Title;
                competencyToUpdate.Description = competency.Description;
                competencyToUpdate.Exercises = competency.Exercises;
                _context.Competencies.Update(competencyToUpdate);
            }
            _context.SaveChanges();
            return competencyToUpdate;
        }

        public bool DeleteCompetency(int id)
        {
            var competencyToDelete = _context.Competencies.Include(c => c.Exercises).Where(e => e.Id == id).FirstOrDefault();
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

        public Exercise? GetNextExercise(Competency competency, ApplicationUser user)
        {
            var currentCompetency = _context.Competencies.Include(c => c.Exercises).Where(e => e.Id == competency.Id).FirstOrDefault();
            var exercises = currentCompetency.Exercises;
            var completeExercises = _context.Submissions.Where(s => s.UserId == user.Id).Select(s => s.ExerciseId).ToList();
            var incompleteExercises = exercises.Where(e => !completeExercises.Contains(e.Id)).OrderBy(e=>e.Order).ToList();
            if (incompleteExercises.Count > 0)
            {
                return incompleteExercises[0];
            }
            else
            {
                return null;
            }
        }

        public Task<List<Submission>> GetUserExerciseSubmissionsAsync(Competency competency, ApplicationUser user)
        {
            return _context.Submissions.Where(s => competency.Exercises.Contains(s.Exercise) && s.User == user).ToListAsync();
        }
    }
}
