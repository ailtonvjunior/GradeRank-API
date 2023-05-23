using GradeRank_Domain.Models;
using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Repositories;
using GradeRank_Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GradeRank_Infrastructure.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly GradeRankContext _context;

    public UserRepository(GradeRankContext context)
    {
      _context = context;
    }
    public async Task InsertUser(UserDbo user)
    {
      await _context.Users.AddAsync(user);
    }
    public async Task<bool> VerifyIfUserExistsByLogin(string login)
    {
      var user = await _context.Users.AnyAsync(u => u.Login == login);
      return user;
    }
  }
}
