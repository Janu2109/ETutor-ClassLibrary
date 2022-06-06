using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.StudentsEnrolled
{
    public class StudentsEnrolled : IStudentsEnrolled
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
