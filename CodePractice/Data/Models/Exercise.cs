namespace CodePractice.Data.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Question { get; set; }
        public string DesiredOutput { get; set; }
        public string Answer { get; set; }
        public string Hint { get; set; }
    }
}
