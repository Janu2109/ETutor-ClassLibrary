using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.Files
{
    public interface IFiles
    {
        int Id { get; set; }
        string Name { get; set; }
        int ModuleId { get; set; }
        int UserId { get; set; }
    }
}
