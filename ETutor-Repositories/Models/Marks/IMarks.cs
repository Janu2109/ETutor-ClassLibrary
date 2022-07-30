using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.Marks
{
    public interface IMarks
    {
        int Id { get; set; }
        int Mark { get; set; }
        int ModuleId { get; set; }
        int UserId { get; set; }
    }
}
