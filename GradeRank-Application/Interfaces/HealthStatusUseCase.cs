﻿using GradeRank_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRank_Application.Interfaces
{
  public interface IHealthStatusUseCase
  {
    Task<HealthStatusDbo> GetStatusUseCase();
  }
}
