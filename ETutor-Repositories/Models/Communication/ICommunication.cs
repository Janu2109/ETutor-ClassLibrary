using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.Communication
{
    public interface ICommunication
    {
        string Message { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int UserId { get; set; }
    }
}
