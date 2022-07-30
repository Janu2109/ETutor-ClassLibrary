using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.Marks
{
    public class Marks : IMarks
    {
        public int Id { get; set; }
        public int Mark { get; set; }
        public int ModuleId { get; set; }
        public int UserId { get; set; }
    }
}
