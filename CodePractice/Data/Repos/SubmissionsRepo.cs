using CodePractice.Data.Interfaces;
using CodePractice.Data.Models;

namespace CodePractice.Data.Repos
{
    public class SubmissionsRepo : ISubmissionsRepo
    {
        private ApplicationDbContext _context;
        public SubmissionsRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddSubmission(Submission submission)
        {
            _context.Submissions.Add(submission);
            _context.SaveChanges();
        }

        public Submission GetSubmission(int id)
        {
            return _context.Submissions.Find(id);
        }

        public void UpdateSubmission(Submission submission)
        {
            _context.Submissions.Update(submission);
            _context.SaveChanges();
        }

        public void DeleteSubmission(Submission submission)
        {
            _context.Submissions.Remove(submission);
            _context.SaveChanges();
        }

        public void DeleteSubmission(int id)
        {
            var submission = GetSubmission(id);
            DeleteSubmission(submission);
        }

        public List<Submission> GetSubmissions()
        {
            return _context.Submissions.ToList();
        }

        public List<Submission> GetPageOfSubmissions(int page, int number)
        {
            return _context.Submissions.Skip(page * number).Take(number).ToList();
        }
    }
}
