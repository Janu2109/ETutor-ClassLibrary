using ETutor_Repositories.Interfaces;
using ETutor_Repositories.Models.Communication;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Repositories
{
    public  class CommunicationRepositoryAsync : RepositoryBase<ICommunication>, ICommunicationRepositoryAsync
    {
        public CommunicationRepositoryAsync() { }

        public CommunicationRepositoryAsync(IDatabase database) : base(database) { }

        public override ICommunication Adapt(IDataReader dataReader)
        {
            return new Communication
            {
                Message = (string)dataReader["Message"].ToString(),
                FirstName = (string)dataReader["FirstName"].ToString(),
                LastName = (string)dataReader["LastName"].ToString(),
                UserId = (int)dataReader["UserId"],
            };
        }

        public async Task<ICollection<ICommunication>> Select(int moduleId)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_SELECT_Messages_ModuleId]", Database.SqlConnection as SqlConnection))
            {
                //Set command type I want to fire
                command.CommandType = CommandType.StoredProcedure;

                //Parameters Stored Proc will be expecting 
                command.Parameters.Add(new SqlParameter("@moduleId", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = moduleId
                });

                using (var classes = await command.ExecuteReaderAsync())
                {
                    return await ReadCollectionAsync(classes, this);
                }
            }
        }

        public async Task<int> Insert(string message, int moduleId, int userId)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_INSERT_Message]", Database.SqlConnection as SqlConnection))
            {
                //Set command type I want to fire
                command.CommandType = CommandType.StoredProcedure;

                //Parameters Stored Proc will be expecting 
                command.Parameters.Add(new SqlParameter("@message", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = message
                });
                command.Parameters.Add(new SqlParameter("@moduleId", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = moduleId

                });
                command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = userId

                });

                return await command.ExecuteNonQueryAsync();
            }

        }
    }
}
