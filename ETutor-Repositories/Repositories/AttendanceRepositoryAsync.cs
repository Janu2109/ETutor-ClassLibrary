using ETutor_Repositories.Interfaces;
using ETutor_Repositories.Models.Attendance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Repositories
{
    public class AttendanceRepositoryAsync : RepositoryBase<IAttendance>, IAttendanceRepositoryAsync
    {
        public AttendanceRepositoryAsync() { }
        public AttendanceRepositoryAsync(IDatabase database) : base(database) { }

        public override IAttendance Adapt(IDataReader dataReader)
        {
            return new Attendance
            {
                Id = (int)dataReader["Id"],
                ModuleId = (int)dataReader["ModuleId"],
                UserId = (int)dataReader["UserId"],
                Date = (string)dataReader["Date"].ToString()

            };
        }

        #region INSERT

        public async Task<int> Insert(int moduleId, int userId, string date)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_INSERT_Attendence]", Database.SqlConnection as SqlConnection))
            {
                //Set command type I want to fire
                command.CommandType = CommandType.StoredProcedure;

                //Parameters Stored Proc will be expecting 
                command.Parameters.Add(new SqlParameter("@moduleId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = moduleId
                });
                command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = userId
                });
                command.Parameters.Add(new SqlParameter("@date", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = date
                });

                return await command.ExecuteNonQueryAsync();
            }
        }

        #endregion
    }
}
