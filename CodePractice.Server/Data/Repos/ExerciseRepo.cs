﻿using CodePractice.Shared.Models;
using CodePractice.Shared.Interfaces;
using CodePractice.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace CodePractice.Data.Repos
{
    public class ExerciseRepo : IExercisesRepo
    {
        private readonly ApplicationDbContext _context;
        public ExerciseRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public Exercise? GetExercise(int id)
        {
            return _context.Exercises.Where(e => e.Id == id).FirstOrDefault();
        }

        public List<Exercise> GetExercises(int page, int pageSize)
        {
            return _context.Exercises.Include(e=>e.Competency).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public Exercise AddExercise(Exercise exercise)
        {
            var returnExercise = _context.Exercises.Add(exercise);
            var competencyToUpdate = _context.Competencies.Where(e => e.Id == returnExercise.Entity.CompetencyId).FirstOrDefault();

            //if (competencyToUpdate != null)
            //{
            //    Exercise lastExercise = _context.Exercises.Where(e => e.Id == competencyToUpdate.LastExerciseId).FirstOrDefault();

            //    if (lastExercise != null)
            //    {
            //        lastExercise.NextExerciseId = returnExercise.Entity.Id;
            //    }
            //    else
            //    {
            //        competencyToUpdate.FirstExerciseId = returnExercise.Entity.Id;
            //    }
            //    //TODO: Make sure returnExercise.Entity.Id is not null
            //}
            _context.SaveChanges();
            return returnExercise.Entity;
        }

        public Exercise? UpdateExercise(Exercise exercise)
        {
            var exerciseToUpdate = _context.Exercises.Where(e => e.Id == exercise.Id).FirstOrDefault();
            if (exerciseToUpdate != null)
            {
                Competency? previousCompetency = _context.Competencies.Where(c=>c.Id==exerciseToUpdate.CompetencyId).FirstOrDefault();
                exerciseToUpdate.Title = exercise.Title;
                exerciseToUpdate.Question = exercise.Question;
                exerciseToUpdate.DesiredOutput = exercise.DesiredOutput;
                exerciseToUpdate.Answer = exercise.Answer;
                exerciseToUpdate.Hint = exercise.Hint;
                exerciseToUpdate.CompetencyId = exercise.CompetencyId;
            }
            _context.SaveChanges();
            return exerciseToUpdate;
        }

        public bool DeleteExercise(int id)
        {
            var exerciseToDelete = _context.Exercises.Where(e => e.Id == id).FirstOrDefault();
            if (exerciseToDelete == null)
            {
                return false;
            }
            ////Reorder exercises in competency
            //if (exerciseToDelete.PreviousExerciseId == null)
            //{
            //    Competency? competencyToUpdate = _context.Competencies.Where(c => c.Id == exerciseToDelete.CompetencyId).FirstOrDefault();
            //    competencyToUpdate.FirstExerciseId = exerciseToDelete.NextExerciseId;
            //}
            //else
            //{
            //    Exercise ? previousExercise = _context.Exercises.Where(e => e.Id == exerciseToDelete.PreviousExerciseId).FirstOrDefault();
            //    previousExercise.NextExerciseId = exerciseToDelete.NextExerciseId;
            //}
            _context.Exercises.Remove(exerciseToDelete);
            _context.SaveChanges();
            return true;
        }

        ////Get next exercise
        //public Exercise? GetNextExercise(Exercise exercise)
        //{
        //    if (exercise == null)
        //    {
        //        return null;
        //    }
        //    return _context.Exercises.Where(e => e.Id == exercise.NextExerciseId).FirstOrDefault();
        //}

        //Get exercise by competency
        public List<Exercise> GetExercisesByCompetency(int competencyId, int page, int pageSize)
        {
            return _context.Exercises.Where(e=>e.CompetencyId == competencyId).Include(e => e.Competency).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
