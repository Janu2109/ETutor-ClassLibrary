using System.Data;
using System.Data.SqlClient;

namespace VehicleLibrary.Repositories
{

    /// <summary>
    /// create and open database connection
    /// </summary>
    public class Database : IDatabase
    {
        public Database() { }

        /// <summary>
        /// constructor to assign the connection string
        /// </summary>
        /// <param name="connectionString"></param>
        public Database(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private string connectionString;
        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
            set
            {
                if (value != connectionString)
                {
                    connectionString = value;
                    Dispose();
                    //create new sqlconnection with the connectionstring that was passsed in
                    SqlConnection = new SqlConnection(connectionString);
                    //open the connection
                    Open();
                }
            }
        }

        /// <summary>
        /// property for sqlconnection which is of type IDbConnection
        /// </summary>
        public IDbConnection SqlConnection { get; private set; }

        /// <summary>
        /// opent the connection to the DB
        /// </summary>
        public void Open()
        {
            //if the connection state is not open we will open it
            if (SqlConnection.State != ConnectionState.Open)
            {
                //opening sqlconnection
                SqlConnection.Open();
            }
        }

        public void Validate()
        {
            if (null != SqlConnection
                && SqlConnection.State != ConnectionState.Open)
            {
                SqlConnection.Open();
            }
        }

        /// <summary>
        /// close and dispose the connection to the DB
        /// </summary>
        public void Dispose()
        {
            //check if the connection is not already closed 
            if (null != SqlConnection)
            {
                //close and dispose the connection
                SqlConnection.Close();
                SqlConnection.Dispose();
            }
        }
    }

}