using GradeRank_Application.Interfaces;
using GradeRank_Domain.Domain.Exceptions;
using GradeRank_Domain.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GradeRank_API.Controllers
{
  public class EvaluationController : Controller
  {
    private readonly IEvaluationService _evaluationService;

    public EvaluationController(IEvaluationService evaluationService)
    {
      _evaluationService = evaluationService;
    }

    [Route("api/[controller]")]
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> CreateNewEvaluation([FromBody] EvaluationComponentRequest evaluation)
    {
      try
      {
        await _evaluationService.CreateNewEvaluation(evaluation);
        return Ok();

      }
      catch (GradeRankException ex)
      {
        return Conflict(ex.Message);
      }
    }

    [AllowAnonymous]
    [HttpDelete ("/api/{idUser}/{idCourse}")]
    public async Task<IActionResult> DeleteEvaluation([FromRoute] int idUser,int idCourse)
    {
      try
      {
        await _evaluationService.DeleteEvaluation(idUser, idCourse);
        return Ok();

      }
      catch (GradeRankException ex)
      {
        return Problem(ex.Message);
      }
    }
  }
}
