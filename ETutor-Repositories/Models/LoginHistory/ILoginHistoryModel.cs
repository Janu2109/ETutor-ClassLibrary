using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.LoginHistory
{
    public interface ILoginHistoryModel
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string City { get; set; }
        DateTime Date { get; set; }
        string Ip { get; set; }
    }
}
