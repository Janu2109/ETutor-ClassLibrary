using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.Attendance
{
    public class Attendance : IAttendance
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public int UserId { get; set; }
        public string Date { get; set; }
    }
}
