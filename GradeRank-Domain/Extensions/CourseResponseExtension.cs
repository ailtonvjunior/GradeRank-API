using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Models.Response;
using GradeRank_Domain.Repositories;
using System.Diagnostics.CodeAnalysis;


namespace GradeRank_Domain.Domain.Extensions
{
  [ExcludeFromCodeCoverage]

  public static class CourseResponseExtension
  {
    public static void FullfullEvaluationTimes(this List<CourseResponse> courseResponseList, List<CourseEvaluationDto> evaluationTimes)
    {
      foreach (var courseResponse in courseResponseList)
      {
        var courseEvaluation = evaluationTimes.FirstOrDefault(dto => dto.IdCourse == courseResponse.Id);
        if (courseEvaluation != null)
        {
          courseResponse.EvaluationTimes = courseEvaluation.EvaluationTimes;
        }
      }
    }
  }
}
