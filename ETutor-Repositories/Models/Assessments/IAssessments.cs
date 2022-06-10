using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.Assessments
{
    public interface IAssessments
    {
        int Id { get; set; }
        int ModuleId { get; set; }
        string Title { get; set; }
        string QuestionOneQ { get; set; }
        string QuestionOneA { get; set; }
        string QuestionOneO { get; set; }
        string QuestionTwoQ { get; set; }
        string QuestionTwoA { get; set; }
        string QuestionTwoO { get; set; }
        string QuestionThreeQ { get; set; }
        string QuestionThreeA { get; set; }
        string QuestionThreeO { get; set; }
        string QuestionFourQ { get; set; }
        string QuestionFourA { get; set; }
        string QuestionFourO { get; set; }
        string QuestionFiveQ { get; set; }
        string QuestionFiveA { get; set; }
        string QuestionFiveO { get; set; }
    }
}
