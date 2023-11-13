﻿using CodePractice.Data.Models;

namespace CodePractice.Data.Interfaces
{
    public interface ICompetenciesRepo
    {
        public List<Competency> GetCompetencies();
        List<Competency> GetCompetencies(int page, int number);
        Competency? GetCompetency(int id);
        Competency? UpdateCompetency(Competency competency);
        Competency AddCompetency(Competency competency);
        bool DeleteCompetency(int id);
        public Exercise GetFirstExercise(int id);
    }
}