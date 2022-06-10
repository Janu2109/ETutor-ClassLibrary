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
                Email = (string)dataReader["Email"].ToString(),
                IsStudent = (bool)dataReader["IsStudent"],
                IsLecturer = (bool)dataReader["IsLecturer"],
                IsAdministrator = (bool)dataReader["IsAdministrator"],
                DateJoined = (DateTime)dataReader["DateJoined"]

            };
        }

        #region SELECT

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

        public async Task<ICollection<IUserModel>> Select_All()
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_GET_Users_All]", Database.SqlConnection as SqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
               
                using (var user = await command.ExecuteReaderAsync())
                { 
                    return await ReadCollectionAsync(user, this);
                }
            }
        }

        public async Task<ICollection<IUserModel>> Select_Users_Lecturers()
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_GET_Users_Lecturers]", Database.SqlConnection as SqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                using (var user = await command.ExecuteReaderAsync())
                {
                    return await ReadCollectionAsync(user, this);
                }
            }
        }

        public async Task<ICollection<IUserModel>> Select_Lecture(int id)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_GET_Lecture]", Database.SqlConnection as SqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = id
                });

                using (var user = await command.ExecuteReaderAsync())
                {
                    return await ReadCollectionAsync(user, this);
                }
            }
        }
        public async Task<ICollection<IUserModel>> Select_Student_CourseId(int id)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_GET_Students_CourseId]", Database.SqlConnection as SqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@courseId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = id
                });

                using (var user = await command.ExecuteReaderAsync())
                {
                    return await ReadCollectionAsync(user, this);
                }
            }
        }



        #endregion

        #region DELETE

        public async Task<int> Delete_User(int userId)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_DELETE_User]", Database.SqlConnection as SqlConnection))
            {
                //Set command type I want to fire
                command.CommandType = CommandType.StoredProcedure;

                //Parameters Stored Proc will be expecting 
                command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = userId
                });

                return await command.ExecuteNonQueryAsync();
            }
        }


        #endregion

        #region INSERT

        public async Task<int> Insert(string userName, string password, string firstName, string lastName, long idNo, string city, string email)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_INSERT_Student]", Database.SqlConnection as SqlConnection))
            {
                //Set command type I want to fire
                command.CommandType = CommandType.StoredProcedure;

                //Parameters Stored Proc will be expecting 
                command.Parameters.Add(new SqlParameter("@userName", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = userName
                });
                command.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = password

                });
                command.Parameters.Add(new SqlParameter("@firstName", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = firstName

                });
                command.Parameters.Add(new SqlParameter("@lastName", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = lastName

                });
                command.Parameters.Add(new SqlParameter("@idNo", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Input,
                    Value = idNo

                });
                command.Parameters.Add(new SqlParameter("@city", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = city

                });
                command.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Input,
                    Value = email

                });
                command.Parameters.Add(new SqlParameter("@isStudent", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Input,
                    Value = true

                });
                command.Parameters.Add(new SqlParameter("@isLecturer", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Input,
                    Value = false

                });
                command.Parameters.Add(new SqlParameter("@isAdministrator", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Input,
                    Value = false

                });

                return await command.ExecuteNonQueryAsync();
            }
        }

        #endregion

        #region UPDATE

        public async Task<int> Update_Role(int userId, bool isStudent, bool isLecture, bool isAdmin)
        {
            Database.Validate();

            using (var command = new SqlCommand("[dbo].[USP_UPDATE_USer_Role]", Database.SqlConnection as SqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = userId
                });
                command.Parameters.Add(new SqlParameter("@isStudent", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Input,
                    Value = isStudent
                });
                command.Parameters.Add(new SqlParameter("@isLecture", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Input,
                    Value = isLecture
                });
                command.Parameters.Add(new SqlParameter("@isAdmin", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Input,
                    Value = isAdmin
                });

                return await command.ExecuteNonQueryAsync();
            }
        }

        #endregion


    }
}
