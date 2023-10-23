using Microsoft.AspNetCore.Identity;

namespace CodePractice.Data.Models
{
    public class Submission
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string UploadedCodeFile { get; set; }
        public int ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }
        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }
        public DateTime SubmissionDate { get; set; }
        public bool IsCorrect { get; set; }
    }
}
