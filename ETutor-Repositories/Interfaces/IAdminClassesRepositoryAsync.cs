using ETutor_Repositories.Models.AdminClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Interfaces
{
    public interface IAdminClassesRepositoryAsync
    {
        Task<ICollection<IAdminClassesModel>> Select_Classes();
    }
}
