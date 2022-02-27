using System;

namespace ETutor_Repositories.Interfaces
{

    public interface IDatabase : IDisposable
    {
        System.Data.IDbConnection SqlConnection { get; }
        string ConnectionString { get; set; }

        void Open();
        void Validate();
    }

}