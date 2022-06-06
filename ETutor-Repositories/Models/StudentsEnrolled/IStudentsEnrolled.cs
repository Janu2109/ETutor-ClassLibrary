using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.StudentsEnrolled
{
    public interface IStudentsEnrolled
    {
        string FirstName { get; set; }
        string LastName { get; set; }  
        string Email { get; set; }
        string Name { get; set; }
    }
}
