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

        Task<ICollection<IUserModel>> Select_Lecture(int id);

        Task<ICollection<IUserModel>> Select_Users_Lecturers();

        Task<int> Update_Role(int userId, bool isStudent, bool isLecture, bool isAdmin);
        Task<int> Delete_User(int userId);
    }
}
