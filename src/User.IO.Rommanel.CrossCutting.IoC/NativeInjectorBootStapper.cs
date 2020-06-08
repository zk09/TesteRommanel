using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using User.IO.Rommanel.Application.Interfaces;
using User.IO.Rommanel.Application.Services;
using User.IO.Rommanel.Domain.Core.Notifications;
using User.IO.Rommanel.Domain.Interface;
using User.IO.Rommanel.Domain.Users.CommandHandler;
using User.IO.Rommanel.Domain.Users.Commands;
using User.IO.Rommanel.Domain.Users.EventHandler;
using User.IO.Rommanel.Domain.Users.Events;
using User.IO.Rommanel.Domain.Users.Repository;
using User.IO.Rommanel.Infra.Data.Context;
using User.IO.Rommanel.Infra.Data.Repository;
using User.IO.Rommanel.Infra.Data.Uow;
using Microsoft.AspNetCore.Http;
using User.IO.Rommanel.Application.AutoMapper;

namespace User.IO.Rommanel.CrossCutting.IoC
{
    public class NativeInjectorBootStapper
    {
        public static void RegisterServices(IServiceCollection services)
        {


            //Application
            var config = AutoMapperConfiguration.RegisterMappings();
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IUserAppService, UserAppSerice>();
            


            //Domain - Eventos 
            services.AddScoped<DomainNotification>();
            services.AddScoped<INotificationHandler<RegisterUserEvent>,RegisterUserEventHandler>();
            services.AddScoped<INotificationHandler<UpdateUserEvent>, UpdateUserEventHandler>();
            services.AddScoped<INotificationHandler<DeleteUserEvent>, DeleteUserEventHandler>();

            //Domain - Command
            services.AddScoped<IRequestHandler<RegisterUserCommand,bool>, RegisterUserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserCommand,bool>, UpdateUserCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteUserCommand,bool>, DeleteUserCommandHandler>();

            //Infra - Data
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<UserContext>();



        }
    }
}
