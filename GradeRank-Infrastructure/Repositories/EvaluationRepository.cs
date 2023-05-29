﻿using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Repositories;
using GradeRank_Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GradeRank_Infrastructure.Repositories
{
  public class EvaluationRepository : IEvaluationRepository
  {
    private readonly GradeRankContext _context;

    public EvaluationRepository(GradeRankContext context)
    {
      _context = context;
    }

    public async Task InsertEvaluation(EvaluationDbo evaluation)
    {
      await _context.Evaluations.AddAsync(evaluation);
    }

    public void DeleteEvaluation(EvaluationDbo evaluation)
    {
      _context.Evaluations.Remove(evaluation);
    }

    public async Task<List<EvaluationDbo?>?> GetEvaluationsByIdUserAndIdCourse(int idUser, int idCourse)
    {
      var evaluation = await _context.Evaluations.Where(e => e.IdUser == idUser && e.IdCourse == idCourse).ToListAsync();
      return evaluation;
    }

    public int GetNumberOfEvaluationsByIdCourse(int idCourse)
    {
      var numRows = _context.Evaluations
        .Select(e => new { e.IdCourse, e.IdUser })
        .Distinct()
        .Count();
      return numRows;
    }
  }
}

