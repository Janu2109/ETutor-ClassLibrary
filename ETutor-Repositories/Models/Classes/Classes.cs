using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.Classes
{
    public class Classes : IClasses
    {
        public int Id { get; set; }
        public int LectureId { get; set; }
        public int ModuleId { get; set; }
        public string Day { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
    }
}
