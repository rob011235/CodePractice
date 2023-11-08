using System.ComponentModel.DataAnnotations;

namespace CodePractice.Data.Models
{
    public class Competency
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public int? FirstExerciseId { get; set; }
        public int? LastExerciseId { get; set; }
    }
}
