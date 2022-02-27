using System;
using VehicleLibrary.Repositories;

namespace VehicleLibrary
{

    public interface IRepositoryDatabase : IDisposable
    {
        IDatabase Database { get; set; }
    }

}