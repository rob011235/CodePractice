namespace CodePractice.Shared.Models
{
    public class Competency
    {
        public int Id { get; set; }
        public string? Title { get; set; } = "New Competency";
        public string? Description { get; set; } = "";
        public virtual List<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
