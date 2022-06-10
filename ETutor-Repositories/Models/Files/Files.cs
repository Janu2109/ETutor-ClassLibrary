using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.Files
{
    public class Files : IFiles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModuleId { get; set; }
        public int UserId { get; set; }
    }
}
