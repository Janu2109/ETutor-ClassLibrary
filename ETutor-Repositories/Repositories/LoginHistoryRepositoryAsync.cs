using ETutor_Repositories.Interfaces;
using ETutor_Repositories.Models.LoginHistory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Repositories
{
    public class LoginHistoryRepositoryAsync : RepositoryBase<ILoginHistoryModel>, ILoginHistoryRepositoryAsync
    {
        public LoginHistoryRepositoryAsync() { }
        public LoginHistoryRepositoryAsync(IDatabase database) : base(database) { }

        public override ILoginHistoryModel Adapt(IDataReader dataReader)
        {
            return new LoginHistoryModel
            {
                FirstName = (string)dataReader["FirstName"].ToString(),
                LastName = (string)dataReader["LastName"].ToString(),
                City = (string)dataReader["City"].ToString(),
                Date = (DateTime)dataReader["Date"],
                Ip = (string)dataReader["Ip"].ToString(),
            };
        }

        public async Task<int> Insert(int userId, string ip)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_INSERT_LoginHistory]", Database.SqlConnection as SqlConnection))
            {
                //Set command type I want to fire
                command.CommandType = CommandType.StoredProcedure;

                //Parameters Stored Proc will be expecting 
                command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = userId
                });
                command.Parameters.Add(new SqlParameter("@ip", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = ip
                });

                return await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<ICollection<ILoginHistoryModel>>Select()
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_GET_LoginHistory]", Database.SqlConnection as SqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                using (var history = await command.ExecuteReaderAsync())
                {
                    return await ReadCollectionAsync(history, this);
                }
            }
        }
    }
}
