using ETutor_Repositories.Models.Communication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Interfaces
{
    public interface ICommunicationRepositoryAsync
    {
        Task<int> Insert(string message, int moduleId, int userId);

        Task<ICollection<ICommunication>> Select(int moduleId);
    }
}
