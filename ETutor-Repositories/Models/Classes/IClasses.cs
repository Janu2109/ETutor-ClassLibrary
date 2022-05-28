using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.Classes
{
    public interface IClasses
    {
        int Id { get; set; }
        int LectureId { get; set; }
        int ModuleId { get; set; }
        string Day { get; set; }
        string TimeStart { get; set; }
        string TimeEnd { get; set; }
    }
}
