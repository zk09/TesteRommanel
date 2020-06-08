using User.IO.Rommanel.Domain.Users.Repository;
using User.IO.Rommanel.Infra.Data.Context;

namespace User.IO.Rommanel.Infra.Data.Repository
{
    public class UserRepository:Repository<Domain.Users.User>, IUserRepository
    {
        public UserRepository(UserContext context) : base(context)
        {

        }
    }
}
