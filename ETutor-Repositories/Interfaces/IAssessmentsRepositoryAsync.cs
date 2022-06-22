using ETutor_Repositories.Models.Assessments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Interfaces
{
    public interface IAssessmentsRepositoryAsync
    {
        Task<ICollection<IAssessments>> Select_Assessments();
        Task<int> Insert(int moduleId, string title, string questionOneQ, string questionOneA, string questionOneO, string questionTwoQ, string questionTwoA, string questionTwoO, string questionThreeQ, string questionThreeA, string questionThreeO, string questionFourQ, string questionFourA, string questionFourO, string questionFiveQ, string questionFiveA, string questionFiveO);
    }
}
