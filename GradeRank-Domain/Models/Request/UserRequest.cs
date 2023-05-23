using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace GradeRank_Domain.Models.Request
{
  public class UserRequest
  {
    public UserRequest(string login, string password)
    {
      Login = login;
      Password = password;
    }

    public string Login { get; set; }
    public string Password { get; set; }
  }
}
