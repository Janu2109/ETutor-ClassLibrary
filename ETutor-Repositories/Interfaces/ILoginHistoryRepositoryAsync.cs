using ETutor_Repositories.Models.LoginHistory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Interfaces
{
    public interface ILoginHistoryRepositoryAsync
    {
        Task<int> Insert(int userId, string ip);

        Task<ICollection<ILoginHistoryModel>>Select();
    }
}
