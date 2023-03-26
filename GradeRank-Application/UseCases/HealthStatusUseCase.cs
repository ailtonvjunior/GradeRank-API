using GradeRank_Application.Interfaces;
using GradeRank_Domain.Models;
using GradeRank_Domain.Repositories;

namespace GradeRank_Application.UseCases
{
  public class HealthStatusUseCase : IHealthStatusUseCase
  {
    private readonly IHealthStatusRepository _healthStatusRepository;

    public HealthStatusUseCase(IHealthStatusRepository healthStatusRepository)
    {
      _healthStatusRepository = healthStatusRepository;
    }

    public Task<HealthStatusDbo> GetStatusUseCase() 
    {
      var healthstatus = _healthStatusRepository.GetHealthStatus();
      return healthstatus;
    }
  }
}
