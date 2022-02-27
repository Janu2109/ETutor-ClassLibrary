using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.User
{
    public class UserModel : IUserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdNo { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public bool IsStudent { get; set; }
        public bool IsLecturer { get; set; }
        public bool IsAdministrator { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
