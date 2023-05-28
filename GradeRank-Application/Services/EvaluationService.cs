using AutoMapper;
using GradeRank_Application.Interfaces;
using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Models.Request;
using GradeRank_Domain.Models.Response;
using GradeRank_Domain.Repositories;
using inter.people.central.Domain.Exceptions;

namespace GradeRank_Application.UseCases
{
  public class EvaluationService : IEvaluationService
  {
    private readonly IEvaluationRepository _evaluationRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public EvaluationService(IEvaluationRepository evaluationRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
      _evaluationRepository = evaluationRepository;
      _mapper = mapper;
      _unitOfWork = unitOfWork;
    }

    public async Task CreateNewEvaluation(EvaluationComponentRequest evaluation)
    {
      var evaluationDbo = await _evaluationRepository.GetEvaluationsByIdUserAndIdCourse(evaluation.IdUser, evaluation.IdCourse);
      if (evaluationDbo != null) 
      {
        throw new GradeRankException("O usuário já possui uma avaliação para esta disciplina");
      }

      var evaluationDboList = _mapper.Map<List<EvaluationDbo>>(evaluation);
      foreach (var item in evaluationDboList)
      {
        await _evaluationRepository.InsertEvaluation(item);
      }
      await _unitOfWork.Save();
    }

    public async Task DeleteEvaluation(int idUser, int idCourse)
    {
      var evaluationDbo = await _evaluationRepository.GetEvaluationsByIdUserAndIdCourse(idUser, idCourse);

      foreach (var item in evaluationDbo)
      {
        _evaluationRepository.DeleteEvaluation(item);
      }
      await _unitOfWork.Save();
    }
  }
}
