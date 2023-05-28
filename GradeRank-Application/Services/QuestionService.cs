using GradeRank_Application.Interfaces;
using GradeRank_Domain.Models.DBO;
using GradeRank_Domain.Models.Reponse;
using GradeRank_Domain.Repositories;
using inter.people.central.Domain.Exceptions;

namespace GradeRank_Application.UseCases
{
    public class QuestionService : IQuestionService
  {
    private readonly IQuestionRepository _questionRepository;

    public QuestionService(IQuestionRepository questionRepository)
    {
      _questionRepository = questionRepository;
    }

    public async Task<List<QuestionResponse>> GetQuestionsListAsync()
    {
      var question = await _questionRepository.GetQuestionsList();
      var questionResponseList = new List<QuestionResponse>(); 

      foreach (var item in question)
      {
        var questionResponse = new QuestionResponse(item.IdQuestion, item.Question);
        questionResponseList.Add(questionResponse);     
      }

      return questionResponseList;
    }
  }
}
