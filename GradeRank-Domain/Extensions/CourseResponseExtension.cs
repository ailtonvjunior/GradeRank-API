using GradeRank_Domain.Models.Response;
using GradeRank_Domain.Repositories;
using System.Diagnostics.CodeAnalysis;


namespace GradeRank_Domain.Domain.Extensions
{
  [ExcludeFromCodeCoverage]

  public static class CourseResponseExtension
  {
    public static void FullfullEvaluationTimes(this List<CourseResponse> courseResponseList, IEvaluationRepository evaluationRepository)
    {
      foreach (var courseResponse in courseResponseList)
      {
        courseResponse.EvaluationTimes = evaluationRepository.GetNumberOfEvaluationsByIdCourse(courseResponse.Id);
      }
    }
  }
}
