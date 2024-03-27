namespace CodePractice.Shared.Models
{
    public class Submission
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public List<FileSubmission> Files { get; set; } = new List<FileSubmission>();
        public int? ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }
        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public bool? IsCorrect { get; set; }
        public string? StudentComments { get; set; }
        public string? InstructorComments { get; set; }
    }
}
