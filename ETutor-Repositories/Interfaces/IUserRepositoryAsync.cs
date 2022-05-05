using ETutor_Repositories.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETutor_Repositories.Interfaces
{
    public interface IUserRepositoryAsync
    {
        Task<IUserModel> Select(string username, string password);

        Task<int> Insert(string userName, string password, string firstName, string lastName, long idNo, string city, string email);

        Task<ICollection<IUserModel>> Select_All();
    }
}
