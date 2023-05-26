

using GradeRank_Domain.Models.DBO;

namespace GradeRank_Domain.Repositories
{
  public interface IUserRepository
  {
    Task InsertUser(UserDbo user);
    Task<bool> VerifyIfUserExistsByLogin(string registration, string email);
    Task<bool> AuthenticateUser(string email, string pwd);
  }
}
