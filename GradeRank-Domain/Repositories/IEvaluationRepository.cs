﻿

using GradeRank_Domain.Models.DBO;

namespace GradeRank_Domain.Repositories
{
  public interface IEvaluationRepository
  {
    Task InsertEvaluation(EvaluationDbo evaluation);
    Task<List<EvaluationDbo?>?> GetEvaluationsByIdUserAndIdCourse(int idUser, int idCourse);
    Task<List<EvaluationDbo>> GetEvaluationsByIdCourse(int idCourse);
    void DeleteEvaluation(EvaluationDbo evaluation);
    //int GetNumberOfEvaluationsByIdCourse(int idCourse);
    List<CourseEvaluationDto> GetNumberOfEvaluations();
  }
}
