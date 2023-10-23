//using CodePractice.Data.Interfaces;
//using CodePractice.Data.Models;

//namespace CodePractice.Data.Mocks
//{
//    public class CompetenciesRepoMock : ICompetenciesRepo
//    {
//        private readonly List<Competency> competencies = new()
//        {
//                new Competency
//                {
//                    Id = 1,
//                     Description = "The ability to write code that is easy to understand and maintain.",
//                     Exercises = new List<Exercise>
//                     {
//                         new Exercise
//                         {
//                             Id = 1,
//                             Title = "FizzBuzz",
//                             Question = "Write a program that prints the numbers from 1 to 100. But for multiples of three print “Fizz” instead of the number and for the multiples of five print “Buzz”. For numbers which are multiples of both three and five print “FizzBuzz”.",
//                             DesiredOutput = "1\n2\nFizz\n4\nBuzz\nFizz\n7\n8\nFizz\nBuzz\n11\nFizz\n13\n14\nFizzBuzz",
//                             Answer = "public class FizzBuzz {\n\tpublic static void main(String[] args) {\n\t\tfor (int i = 1; i <= 100; i++) {\n\t\t\tif (i % 15 == 0) {\n\t\t\t\tSystem.out.println(\"FizzBuzz\");\n\t\t\t} else if (i % 3 == 0) {\n\t\t\t\tSystem.out.println(\"Fizz\");\n\t\t\t} else if (i % 5 == 0) {\n\t\t\t\tSystem.out.println(\"Buzz\");\n\t\t\t} else {\n\t\t\t\tSystem.out.println(i);\n\t\t\t}\n\t\t}\n\t}\n}",
//                             Hint = "Try using a for loop and if statements."
//                         },
//                         new Exercise
//                         {
//                             Id = 2,
//                             Title = "Reverse a String",
//                             Question = "Write a function that reverses a string. The input string is given as an array of characters char[]. Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.",
//                             DesiredOutput = "olleh",
//                             Answer = "class Solution {\n\tpublic void reverseString(char[] s) {\n\t\tint i = 0;\n\t\tint j = s.length - 1;\n\t\twhile (i < j) {\n\t\t\tchar temp"
//                         }
//                     },
//                }
//            };

//        public CompetenciesRepoMock()
//        {

//        }
//        public async Task<Competency?> GetCompetencyAsync(int id)
//        {
//            Competency? competency = await Task.FromResult(competencies.Where(e => e.Id == id).FirstOrDefault());
//            return competency;
//        }

//        public Task<IEnumerable<Competency>> GetCompetenciesAsync(int page, int number)
//        {
//            return Task.FromResult(competencies.Skip((page - 1) * number).Take(number));
//        }

//        public Task<Competency> AddCompetencyAsync(Competency competency)
//        {
//            competency.Id = competencies.Max(e => e.Id) + 1;
//            competencies.Add(competency);
//            return Task.FromResult(competency);
//        }

//        public Task<Competency?> UpdateCompetencyAsync(Competency competency)
//        {
//            var competencyToUpdate = competencies.Where(e => e.Id == competency.Id).FirstOrDefault();
//            if (competencyToUpdate != null)
//            {
//                competencyToUpdate.Title = competency.Title;
//                competencyToUpdate.Description = competency.Description;
//                competencyToUpdate.Exercises = competency.Exercises;
//            }
//            return Task.FromResult(competencyToUpdate);
//        }

//        public bool DeleteCompetencyAsync(int id)
//        {
//            var exerciseToDelete = competencies.Where(e => e.Id == id).FirstOrDefault();
//            if (exerciseToDelete != null)
//            {
//                competencies.Remove(exerciseToDelete);
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }
//    }
//}
