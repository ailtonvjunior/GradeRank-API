using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace GradeRank_Domain.Models.Reponse
{
    public class QuestionResponse
    {
    public QuestionResponse(int idQuestion, string question)
    {
      IdQuestion = idQuestion;
      Question = question;
    }

    [Key]
        [Column("id_question")]
        public int IdQuestion { get; set; }

        [Column("desc_question")]
        public string Question { get; set; }

    }
}



