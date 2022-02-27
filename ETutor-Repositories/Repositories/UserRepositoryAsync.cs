using ETutor_Repositories.Interfaces;
using ETutor_Repositories.Models.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ETutor_Repositories.Repositories
{
    public class UserRepositoryAsync : RepositoryBase<IUserModel>, IUserRepositoryAsync
    {
        public UserRepositoryAsync() { }
        public UserRepositoryAsync(IDatabase database) : base(database) { }

        public override IUserModel Adapt(IDataReader dataReader)
        {
            return new UserModel
            {
                Id = (int)dataReader["Id"],
                UserName = (string)dataReader["UserName"].ToString(),
                Password = (string)dataReader["Password"].ToString(),
                FirstName = (string)dataReader["FirstName"].ToString(),
                LastName = (string)dataReader["LastName"].ToString(),
                IdNo = (int)dataReader["Id"],
                City = (string)dataReader["City"].ToString(),
                Email = (string)dataReader["City"].ToString(),
                IsStudent = (bool)dataReader["IsStudent"],
                IsLecturer = (bool)dataReader["IsLecturer"],
                IsAdministrator = (bool)dataReader["IsAdministrator"],
                DateJoined = (DateTime)dataReader["DateJoined"]

            };
        }

        public async Task<IUserModel> Select(string username, string password)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_GET_User]", Database.SqlConnection as SqlConnection))
            {
                //Set command type I want to fire
                command.CommandType = CommandType.StoredProcedure;

                //Parameters Stored Proc will be expecting 
                command.Parameters.Add(new SqlParameter("@username", SqlDbType.Text)
                {
                    Direction = ParameterDirection.Input,
                    Value = username
                });
                command.Parameters.Add(new SqlParameter("@password", SqlDbType.Text)
                {
                    Direction = ParameterDirection.Input,
                    Value = password
                });

                using (var user = await command.ExecuteReaderAsync())
                {
                    return await ReadAsync(user, this);
                }
            }
        }
    }
}
