using AutoMapper;
using User.IO.Rommanel.Application.ViewModels;

namespace User.IO.Rommanel.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Domain.Users.User, UserViewModel>();
        }
    }
}
