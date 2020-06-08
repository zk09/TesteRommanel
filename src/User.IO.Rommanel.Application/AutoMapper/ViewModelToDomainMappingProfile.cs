using AutoMapper;
using User.IO.Rommanel.Application.ViewModels;
using User.IO.Rommanel.Domain.Users.Commands;


namespace User.IO.Rommanel.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {

        public ViewModelToDomainMappingProfile()
        {

           CreateMap<UserViewModel, RegisterUserCommand>()
                .ConstructUsing(x => new RegisterUserCommand(x.Name, x.Email, x.Cpf, x.DateBirth,x.City,x.ZipCode, x.State));

       
            CreateMap<UserViewModel, UpdateUserCommand>()
                 .ConstructUsing(x => new UpdateUserCommand(x.Id,x.Name, x.Email, x.Cpf, x.DateBirth, x.City, x.ZipCode, x.State));

            CreateMap<UserViewModel, DeleteUserCommand>()
                .ConstructUsing(x => new DeleteUserCommand(x.Id));

        }
    }
}
