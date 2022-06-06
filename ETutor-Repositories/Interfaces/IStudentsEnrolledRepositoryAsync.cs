using ETutor_Repositories.Models.StudentsEnrolled;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Interfaces
{
    public interface IStudentsEnrolledRepositoryAsync
    {
        Task<ICollection<IStudentsEnrolled>> Select();
    }
}
