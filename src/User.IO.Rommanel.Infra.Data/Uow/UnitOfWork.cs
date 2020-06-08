using User.IO.Rommanel.Domain.Core.Commands;
using User.IO.Rommanel.Domain.Interface;
using User.IO.Rommanel.Infra.Data.Context;

namespace User.IO.Rommanel.Infra.Data.Uow
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly UserContext _context;

        public UnitOfWork(UserContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAfected = _context.SaveChanges();

            return new CommandResponse(rowsAfected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
