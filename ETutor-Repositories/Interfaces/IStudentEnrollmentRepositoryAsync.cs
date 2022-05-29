using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Interfaces
{
    public interface IStudentEnrollmentRepositoryAsync
    {
        Task<int> Insert(int userId, int courseId);
    }
}
