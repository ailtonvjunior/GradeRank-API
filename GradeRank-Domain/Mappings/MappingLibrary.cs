using AutoMapper;
using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Models.Response;
using GradeRank_Domain.Models.Request;
using System.Diagnostics.CodeAnalysis;

namespace inter.people.central.Domain.Mappings
{
  [ExcludeFromCodeCoverage]
  public class MappingLibrary : Profile
  {
    public MappingLibrary()
    {
      MappingUser();
      MappingQuestion();
      MappingEvaluation();
    }

    private void MappingUser()
    {
      CreateMap<UserRequest, UserDbo>();
    }

    private void MappingQuestion()
    {
      CreateMap<QuestionDbo, QuestionResponse>();
    }

    private void MappingEvaluation()
    {
      CreateMap<EvaluationComponentRequest, List<EvaluationDbo>>()
          .AfterMap((src, dest, context) =>
          {
            foreach (var evaluationRequest in src.EvaluationRequest)
            {
              var evaluationDbo = context.Mapper.Map<EvaluationRequest, EvaluationDbo>(evaluationRequest);
              evaluationDbo.IdCourse = src.IdCourse;
              evaluationDbo.IdUser = src.IdUser;
              dest.Add(evaluationDbo);
            }
          });

      CreateMap<EvaluationRequest, EvaluationDbo>()
          .ForMember(dest => dest.EvaluationDate, opt => opt.MapFrom(src => DateTime.Now));
    }

  }
}
