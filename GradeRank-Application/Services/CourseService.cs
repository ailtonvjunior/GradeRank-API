using AutoMapper;
using GradeRank_Application.Interfaces;
using GradeRank_Domain.Domain.Extensions;
using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Models.Request;
using GradeRank_Domain.Models.Response;
using GradeRank_Domain.Repositories;

namespace GradeRank_Application.UseCases
{
    public class CourseService : ICourseService
  {
    private readonly ICourseRepository _courseRepository;
    private readonly IEvaluationRepository _evaluationRepository;

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork, IMapper mapper, IEvaluationRepository evaluationRepository)
    {
      _courseRepository = courseRepository;
      _unitOfWork = unitOfWork;
      _mapper = mapper;
      _evaluationRepository = evaluationRepository;
    }

    public List<CourseResponse> GetCoursesList()
    {
      var courseDbo = _courseRepository.GetCoursesList().Result;
      var courseResponse = _mapper.Map<List<CourseResponse>>(courseDbo);
      var evaluationTimes = _evaluationRepository.GetNumberOfEvaluations();
      CourseResponseExtension.FullfullEvaluationTimes(courseResponse, evaluationTimes);

      return courseResponse;
    }
    
    public CourseDbo? GetCourseById(int id)
    {
      return _courseRepository.GetCourseById(id).Result;
    }

  }
}
