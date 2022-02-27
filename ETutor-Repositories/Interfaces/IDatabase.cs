using System;

namespace VehicleLibrary.Repositories
{

    public interface IDatabase : IDisposable
    {
        System.Data.IDbConnection SqlConnection { get; }
        string ConnectionString { get; set; }

        void Open();
        void Validate();
    }

}