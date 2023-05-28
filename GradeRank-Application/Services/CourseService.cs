using GradeRank_Application.Interfaces;
using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Models.Request;
using GradeRank_Domain.Repositories;
using inter.people.central.Domain.Exceptions;

namespace GradeRank_Application.UseCases
{
    public class CourseService : ICourseService
  {
    private readonly ICourseRepository _courseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
    {
      _courseRepository = courseRepository;
      _unitOfWork = unitOfWork;
    }

    public List<CourseDbo> GetCoursesList()
    {
      return _courseRepository.GetCoursesList().Result;
    }
    
    public CourseDbo? GetCourseById(int id)
    {
      return _courseRepository.GetCourseById(id).Result;
    }
  }
}
