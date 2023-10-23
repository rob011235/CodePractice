namespace CodePractice.Data.Models
{
    public class Competency
    {
        public int Id { get; set; }
        public string Title { get; set; }    
        public string Description { get; set; }
        public virtual IEnumerable<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
