using System;
using ETutor_Repositories.Interfaces;

namespace ETutor_Repositories.Interfaces
{

    public interface IRepositoryDatabase : IDisposable
    {
        IDatabase Database { get; set; }
    }

}