﻿using GradeRank_Application.Interfaces;
using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Models.Request;
using GradeRank_Domain.Repositories;
using inter.people.central.Domain.Exceptions;

namespace GradeRank_Application.UseCases
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
      _userRepository = userRepository;
      _unitOfWork = unitOfWork;
    }

    public async Task CreateNewUser(UserRequest user)
    {
      var userDbo = new UserDbo (user.Name, user.Registration, user.Email, user.Password);
      if (!_userRepository.VerifyIfUserExistsByLogin(user.Registration, user.Email).Result)
      {
        await _userRepository.InsertUser(userDbo);
        await _unitOfWork.Save();
      }
      else
        throw new GradeRankException("Usuário já cadastrado na base de dados");
    }
    
    public Boolean AuthenticateUser(string email, string pwd)
    {
      return _userRepository.AuthenticateUser(email, pwd).Result;
    }
  }
}
