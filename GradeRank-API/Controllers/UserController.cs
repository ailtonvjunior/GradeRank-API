using GradeRank_Application.Interfaces;
using GradeRank_Domain.Models.Request;
using inter.people.central.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GradeRank_API.Controllers
{
  [Route("api/[controller]")]

  public class LoginController : Controller
  {
    private readonly IUserService _userService;

    public LoginController(IUserService userService)
    {
      _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateNewUser([FromBody] UserRequest user)
    {
      try
      {
        await _userService.CreateNewUser(user);
        return Ok();

      }
      catch (GradeRankException ex)
      {
        return Conflict(ex.Message);
      }
    }
  }
}
