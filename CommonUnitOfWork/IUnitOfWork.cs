using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IShoePost Shoe { get; }
        int Commit();
    }
}
