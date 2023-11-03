namespace CodePractice.Data.Models
{
    public class Competency
    {
        public int Id { get; set; }
        public string Title { get; set; }    
        public string Description { get; set; }
        public int? FirstExerciseId { get; set; }
        public int? LastExerciseId { get; set; }
    }
}
