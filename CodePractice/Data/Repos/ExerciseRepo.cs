using CodePractice.Data.Interfaces;
using CodePractice.Data.Models;

namespace CodePractice.Data.Repos
{
    public class ExerciseRepo : IExerciseRepo
    {
        private readonly List<Exercise> exercises = new()
        {
                new Exercise
                {
                    Id = 1,
                    Title = "FizzBuzz",
                    Question = "Write a program that prints the numbers from 1 to 100. But for multiples of three print “Fizz” instead of the number and for the multiples of five print “Buzz”. For numbers which are multiples of both three and five print “FizzBuzz”.",
                    DesiredOutput = "1\n2\nFizz\n4\nBuzz\nFizz\n7\n8\nFizz\nBuzz\n11\nFizz\n13\n14\nFizzBuzz",
                    Answer = "public class FizzBuzz {\n\tpublic static void main(String[] args) {\n\t\tfor (int i = 1; i <= 100; i++) {\n\t\t\tif (i % 15 == 0) {\n\t\t\t\tSystem.out.println(\"FizzBuzz\");\n\t\t\t} else if (i % 3 == 0) {\n\t\t\t\tSystem.out.println(\"Fizz\");\n\t\t\t} else if (i % 5 == 0) {\n\t\t\t\tSystem.out.println(\"Buzz\");\n\t\t\t} else {\n\t\t\t\tSystem.out.println(i);\n\t\t\t}\n\t\t}\n\t}\n}",
                    Hint = "Try using a for loop and if statements."
                },
                new Exercise
                {
                    Id = 2,
                    Title = "Reverse a String",
                    Question = "Write a function that reverses a string. The input string is given as an array of characters char[]. Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.",
                    DesiredOutput = "olleh",
                    Answer = "class Solution {\n\tpublic void reverseString(char[] s) {\n\t\tint i = 0;\n\t\tint j = s.length - 1;\n\t\twhile (i < j) {\n\t\t\tchar temp"
                }
            };

        public ExerciseRepo()
        {

        }
        public Task<Exercise?> GetExerciseAsync(int id)
        {
            return Task.FromResult(exercises.Where(e => e.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<Exercise>> GetExercisesAsync(int page, int number)
        {
            return Task.FromResult(exercises.Skip((page - 1) * number).Take(number));
        }

        public Task<Exercise> AddExerciseAsync(Exercise exercise)
        {
            exercise.Id = exercises.Max(e => e.Id) + 1;
            exercises.Add(exercise);
            return Task.FromResult(exercise);
        }

        public Task<Exercise?> UpdateExerciseAsync(Exercise exercise)
        {
            var exerciseToUpdate = exercises.Where(e => e.Id == exercise.Id).FirstOrDefault();
            if (exerciseToUpdate != null)
            {
                exerciseToUpdate.Title = exercise.Title;
                exerciseToUpdate.Question = exercise.Question;
                exerciseToUpdate.DesiredOutput = exercise.DesiredOutput;
                exerciseToUpdate.Answer = exercise.Answer;
                exerciseToUpdate.Hint = exercise.Hint;
            }
            return Task.FromResult(exerciseToUpdate);
        }

        public bool DeleteExerciseAsync(int id)
        {
            var exerciseToDelete = exercises.Where(e => e.Id == id).FirstOrDefault();
            if (exerciseToDelete != null)
            {
                exercises.Remove(exerciseToDelete);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
