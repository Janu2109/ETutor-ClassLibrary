using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.Attendance
{
    public interface IAttendance
    {
        int Id { get; set; }
        int ModuleId { get; set; }
        int UserId { get; set; }
        string Date { get; set; }
    }
}
