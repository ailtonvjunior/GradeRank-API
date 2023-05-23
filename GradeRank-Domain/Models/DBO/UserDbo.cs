using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace GradeRank_Domain.Models.DBO
{
  [Table("gr_users")]
  public class UserDbo
  {
    public UserDbo(string login, string password)
    {
      Login = login;
      Password = password;
    }

    [Key]
    [Column("id_user")]
    public int Id { get; set; }

    [Column("login_user")]
    public string Login { get; set; }

    [Column("pwd_user")]
    public string Password { get; set; }
  }
}


