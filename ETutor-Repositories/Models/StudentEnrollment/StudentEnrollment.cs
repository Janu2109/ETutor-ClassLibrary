using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.StudentEnrollment
{
    public  class StudentEnrollment : IStudentEnrollment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
    }
}
