using CodePractice.Shared.Models;

namespace CodePractice.Shared.Interfaces
{
    public interface ISubmissionsRepo
    {
        void AddSubmission(Submission submission);
        void DeleteSubmission(int id);
        void DeleteSubmission(Submission submission);
        List<Submission> GetPageOfSubmissions(int page, int number);
        Submission GetSubmission(int id);
        List<Submission> GetSubmissions();
        void UpdateSubmission(Submission submission);
    }
}