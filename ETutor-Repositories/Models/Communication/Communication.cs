using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.Communication
{
    public class Communication : ICommunication
    {
        public string Message { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
    }
}
