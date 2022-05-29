using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.StudentEnrollment
{
    public interface IStudentEnrollment
    {
        int Id { get; set; }
        int UserId { get; set; }
        int CourseId { get; set; }
    }
}
