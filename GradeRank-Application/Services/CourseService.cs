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
    private readonly IQuestionRepository _questionRepository;

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork, IMapper mapper, IEvaluationRepository evaluationRepository, IQuestionRepository questionRepository)
    {
      _courseRepository = courseRepository;
      _unitOfWork = unitOfWork;
      _mapper = mapper;
      _evaluationRepository = evaluationRepository;
      _questionRepository = questionRepository;
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

    public List<CourseEvaluationQuestionRequest> GetCourseEvaluation(int idCourse)
    {
      List<CourseEvaluationQuestionRequest> courseEvaluation = new List<CourseEvaluationQuestionRequest>();
      List<EvaluationDbo> courseEvaluations = _evaluationRepository.GetEvaluationsByIdCourse(idCourse).Result;
      var courseEvaluationsPerQuestion = courseEvaluations.GroupBy(evaluation => evaluation.IdQuestion);
      List<QuestionDbo> questions = _questionRepository.GetQuestionsList().Result;
      foreach (var evaluation in courseEvaluationsPerQuestion.AsQueryable())
      {
        string questionDescription = questions.Find(question => question.IdQuestion == evaluation.Key).Question;
        double questionAverageValue = evaluation.Average(d => d.ValueEvaluation);
        CourseEvaluationQuestionRequest question = new CourseEvaluationQuestionRequest(questionDescription, questionAverageValue);
        courseEvaluation.Add(question);
      }
      return courseEvaluation;
    }
  }
}
