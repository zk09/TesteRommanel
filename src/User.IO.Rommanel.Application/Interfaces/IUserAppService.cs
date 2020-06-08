using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using User.IO.Rommanel.Application.ViewModels;

namespace User.IO.Rommanel.Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        Task<IEnumerable<UserViewModel>> GetAll();
        Task<UserViewModel> GetById(Guid id);
        Task<bool> Register(UserViewModel userViewModel);
        Task<bool> Update(UserViewModel userViewModel);
        Task<bool> Delete(Guid id);

    }
}
