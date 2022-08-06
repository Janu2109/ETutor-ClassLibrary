using System;
using System.Collections.Generic;
using System.Text;

namespace ETutor_Repositories.Models.LoginHistory
{
    public class LoginHistoryModel : ILoginHistoryModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public DateTime Date { get; set; }
        public string Ip { get; set; }
    }
}
