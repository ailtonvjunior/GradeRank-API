using GradeRank_Domain.Models;
using GradeRank_Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRank_Application.Interfaces
{
  public interface IUserService
  {
    Task CreateNewUser(UserRequest user);
  }
}
