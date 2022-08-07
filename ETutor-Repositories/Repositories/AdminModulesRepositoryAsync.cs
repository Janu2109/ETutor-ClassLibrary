using ETutor_Repositories.Interfaces;
using ETutor_Repositories.Models.AdminModules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Repositories
{
    public class AdminModulesRepositoryAsync : RepositoryBase<IAdminModulesModel>, IAdminModulesRepositoryAsync
    {
        public AdminModulesRepositoryAsync() { }

        public AdminModulesRepositoryAsync(IDatabase database) : base(database) { }

        public override IAdminModulesModel Adapt(IDataReader dataReader)
        {
            return new AdminModulesModel
            {
                Name = (string)dataReader["Name"].ToString(),
                Description = (string)dataReader["Description"].ToString(),
                Course = (string)dataReader["Course"].ToString(),
                LectureFirstName = (string)dataReader["LectureFirstName"].ToString(),
                LectureLastName = (string)dataReader["LectureLastName"].ToString(),
            };
        }

        public async Task<ICollection<IAdminModulesModel>> Select_Modules()
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_GET_Modules_Report]", Database.SqlConnection as SqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                using (var modules = await command.ExecuteReaderAsync())
                {
                    return await ReadCollectionAsync(modules, this);
                }
            }
        }
    }
}
