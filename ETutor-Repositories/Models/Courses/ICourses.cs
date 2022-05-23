using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.Courses
{
    public interface ICourses
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Duration { get; set; }
    }
}
