using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.Assessments
{
    public class Assessments : IAssessments
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string Title { get; set; }
        public string QuestionOneQ { get; set; }
        public string QuestionOneA { get; set; }
        public string QuestionOneO { get; set; }
        public string QuestionTwoQ { get; set; }
        public string QuestionTwoA { get; set; }
        public string QuestionTwoO { get; set; }
        public string QuestionThreeQ { get; set; }
        public string QuestionThreeA { get; set; }
        public string QuestionThreeO { get; set; }
        public string QuestionFourQ { get; set; }
        public string QuestionFourA { get; set; }
        public string QuestionFourO { get; set; }
        public string QuestionFiveQ { get; set; }
        public string QuestionFiveA { get; set; }
        public string QuestionFiveO { get; set; }
    }
}
