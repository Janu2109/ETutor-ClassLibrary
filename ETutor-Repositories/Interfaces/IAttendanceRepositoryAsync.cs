using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Interfaces
{
    public interface IAttendanceRepositoryAsync
    {
        Task<int> Insert(int moduleId, int userId, string date);
    }
}
