using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.Courses
{
    public  class Courses : ICourses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
    }
}
