using System;
using User.IO.Rommanel.Domain.Core.Commands;

namespace User.IO.Rommanel.Domain.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
