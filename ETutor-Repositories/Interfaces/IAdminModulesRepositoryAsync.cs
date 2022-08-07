using ETutor_Repositories.Models.AdminModules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Interfaces
{
    public interface IAdminModulesRepositoryAsync
    {
        Task<ICollection<IAdminModulesModel>> Select_Modules();
    }
}
