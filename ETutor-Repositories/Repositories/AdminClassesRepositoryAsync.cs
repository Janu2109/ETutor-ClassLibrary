using ETutor_Repositories.Interfaces;
using ETutor_Repositories.Models.AdminClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Repositories
{
    public class AdminClassesRepositoryAsync : RepositoryBase<IAdminClassesModel>, IAdminClassesRepositoryAsync
    {
        public AdminClassesRepositoryAsync() { }
        public AdminClassesRepositoryAsync(IDatabase database) : base(database) { }

        public override IAdminClassesModel Adapt(IDataReader dataReader)
        {
            return new AdminClassesModel
            {
                Day = (string)dataReader["Day"].ToString(),
                TimeStart= (string)dataReader["TimeStart"].ToString(),
                TimeEnd= (string)dataReader["TimeEnd"].ToString(),
                LectureFirstName = (string)dataReader["LectureFirstName"].ToString(),
                LectureLastName = (string)dataReader["LectureLastName"].ToString(),
                Module = (string)dataReader["Module"].ToString(),
            };
        }
        public async Task<ICollection<IAdminClassesModel>> Select_Classes()
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_GET_Classes_Report]", Database.SqlConnection as SqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                using (var classes = await command.ExecuteReaderAsync())
                {
                    return await ReadCollectionAsync(classes, this);
                }
            }
        }
    }
}
