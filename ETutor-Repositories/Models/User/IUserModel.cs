using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.User
{
    public interface IUserModel
    {
        int Id { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int IdNo { get; set; }
        string City { get; set; }
        string Email { get; set; }
        bool IsStudent { get; set; }
        bool IsLecturer { get; set; }
        bool IsAdministrator { get; set; }
        DateTime DateJoined { get; set; } 

    }
}
