﻿using GradeRank_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRank_Domain.Repositories
{
  public interface IHealthStatusRepository 
  {
    Task<HealthStatusDbo?> GetHealthStatus();
  }
}
