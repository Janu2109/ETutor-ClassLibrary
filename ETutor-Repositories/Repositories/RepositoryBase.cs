using ETutor_Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ETutor_Repositories.Repositories
{
    public abstract class RepositoryBase<T> : RepositoryBase, IAdaptor<IDataReader, T>
    {
        public RepositoryBase() { }

        public RepositoryBase(IDatabase database) : base(database) { }

        public abstract T Adapt(IDataReader input);
    }

    public abstract class RepositoryBase : IRepositoryDatabase
    {
        public RepositoryBase() { }

        public RepositoryBase(IDatabase database)
        {
            Database = database;
        }

        public IDatabase Database { get; set; }

        public void Dispose()
        {
            if (null != Database)
            {
                Database.Dispose();
            }
        }

        protected void VerifyDataReader(IDataReader datareader)
        {
            if (datareader == null)
            {
                throw new ArgumentNullException();
            }

            if (datareader.IsClosed)
            {
                throw new ArgumentOutOfRangeException("The data reader is closed and cannot be read.");
            }
        }

        public virtual T Read<T>(IDataReader datareader,
                                 IAdaptor<System.Data.IDataReader, T> adaptor)
        {
            VerifyDataReader(datareader);

            if (datareader.Read())
            {
                return adaptor.Adapt(datareader);
            }
            else
            {
                return default;
            }
        }

        public virtual async Task<T> ReadAsync<T>(SqlDataReader datareader,
                                 IAdaptor<System.Data.IDataReader, T> adaptor)
        {
            VerifyDataReader(datareader);

            if (await datareader.ReadAsync())
            {
                return adaptor.Adapt(datareader);
            }
            else
            {
                return default;
            }
        }

        public ICollection<T> ReadCollection<T>(IDataReader datareader,
                                                IAdaptor<System.Data.IDataReader, T> adaptor)
        {
            // Ensure the datareader is valid
            VerifyDataReader(datareader);

            var obj = new List<T>();
            while (datareader.Read())
            {
                //return a new User object with the data filled in for the User
                obj.Add(adaptor.Adapt(datareader));
            }

            return obj;
        }

        public async Task<ICollection<T>> ReadCollectionAsync<T>(SqlDataReader datareader,
                                                IAdaptor<System.Data.IDataReader, T> adaptor)
        {
            // Ensure the datareader is valid
            VerifyDataReader(datareader);

            var obj = new List<T>();
            while (await datareader.ReadAsync())
            {
                //return a new User object with the data filled in for the User
                obj.Add(adaptor.Adapt(datareader));
            }

            return obj;
        }

        public virtual T ExecuteReaderItem<T>(string commandString,
                                              IAdaptor<System.Data.IDataReader, T> adaptor,
                                              params SqlParameter[] sqlParameters)
        {
            return ExecuteReaderCollection<T>(commandString, adaptor, sqlParameters).FirstOrDefault();
        }

        public virtual ICollection<T> ExecuteReaderCollection<T>(string commandString,
                                                                 IAdaptor<System.Data.IDataReader, T> adaptor,
                                                                 params SqlParameter[] sqlParameters)
        {
            //create sqlcommand to run the _UPDATE_Bin User Stored Procedure
            using (var command = new SqlCommand(commandString, Database.SqlConnection as SqlConnection))
            {
                //set commandType that i want to fire
                command.CommandType = CommandType.StoredProcedure;

                if (null != sqlParameters
                    && sqlParameters.Length > 0)
                {
                    foreach (var sqlParameter in sqlParameters)
                    {
                        command.Parameters.Add(sqlParameter);
                    }
                }

                Database.Validate();
                using (IDataReader datareader = command.ExecuteReader())
                {
                    //return the data that if read from the query
                    return ReadCollection(datareader, adaptor);
                }
            }
        }

        public virtual async Task<ICollection<T>> ExecuteReaderCollectionAsync<T>(string commandString,
                                                                 IAdaptor<System.Data.IDataReader, T> adaptor,
                                                                 params SqlParameter[] sqlParameters)
        {
            //create sqlcommand to run the _UPDATE_Bin User Stored Procedure
            using (var command = new SqlCommand(commandString, Database.SqlConnection as SqlConnection))
            {
                //set commandType that i want to fire
                command.CommandType = CommandType.StoredProcedure;

                if (null != sqlParameters
                    && sqlParameters.Length > 0)
                {
                    foreach (var sqlParameter in sqlParameters)
                    {
                        command.Parameters.Add(sqlParameter);
                    }
                }

                Database.Validate();
                using (var datareader = await command.ExecuteReaderAsync())
                {
                    //return the data that if read from the query
                    return await ReadCollectionAsync(datareader, adaptor);
                }
            }
        }

        public virtual int ExecuteNonQuery(string commandString,
                                           params SqlParameter[] sqlParameters)
        {
            //create sqlcommand to run the _UPDATE_Bin User Stored Procedure
            using (var command = new SqlCommand(commandString, Database.SqlConnection as SqlConnection))
            {
                //set commandType that i want to fire
                command.CommandType = CommandType.StoredProcedure;

                if (null != sqlParameters
                    && sqlParameters.Length > 0)
                {
                    foreach (var sqlParameter in sqlParameters)
                    {
                        command.Parameters.Add(sqlParameter);
                    }
                }

                Database.Validate();
                //run the command(query)
                int result = command.ExecuteNonQuery();

                //return the ID
                return result;
            }
        }

        public virtual async Task<int> ExecuteNonQueryAsync(string commandString,
                                           params SqlParameter[] sqlParameters)
        {
            //create sqlcommand to run the _UPDATE_Bin User Stored Procedure
            using (var command = new SqlCommand(commandString, Database.SqlConnection as SqlConnection))
            {
                //set commandType that i want to fire
                command.CommandType = CommandType.StoredProcedure;

                if (null != sqlParameters
                    && sqlParameters.Length > 0)
                {
                    foreach (var sqlParameter in sqlParameters)
                    {
                        command.Parameters.Add(sqlParameter);
                    }
                }

                Database.Validate();
                //run the command(query)
                int result = await command.ExecuteNonQueryAsync();

                //return the ID
                return result;
            }
        }
    }
}