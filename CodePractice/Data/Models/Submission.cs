using Microsoft.AspNetCore.Identity;

namespace CodePractice.Data.Models
{
    public class Submission
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public List<File> Files { get; set; }=new List<File>();
        public int? ExerciseId { get; set; }
        public int? UserId { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public bool? IsCorrect { get; set; }
        public string? StudentComments { get; set; }
        public string? InstructorComments { get; set; }
    }
}
