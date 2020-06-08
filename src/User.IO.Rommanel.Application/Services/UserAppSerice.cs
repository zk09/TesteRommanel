using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using User.IO.Rommanel.Application.Interfaces;
using User.IO.Rommanel.Application.ViewModels;
using User.IO.Rommanel.Domain.Users.Commands;
using User.IO.Rommanel.Domain.Users.Repository;

namespace User.IO.Rommanel.Application.Services
{
    public class UserAppSerice : IUserAppService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserAppSerice(IMediator mediator, IMapper mapper, IUserRepository userRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _userRepository = userRepository;

        }
        public async Task<bool> Register(UserViewModel userViewModel)
        {
       
                var registerCommand = _mapper.Map<RegisterUserCommand>(userViewModel);
                return await _mediator.Send(registerCommand);
         
        }

        public async Task<bool> Update(UserViewModel userViewModel)
        {
            var updateCommand = _mapper.Map<UpdateUserCommand>(userViewModel);
            return await _mediator.Send(updateCommand);
        }
        public async Task<bool> Delete(Guid id)
        {
           return await _mediator.Send(new DeleteUserCommand(id));
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            return await Task.FromResult(_mapper.Map<IEnumerable<UserViewModel>>(_userRepository.GetAll()));
        }

        public async Task<UserViewModel> GetById(Guid id)
        {
            return await Task.FromResult(_mapper.Map<UserViewModel>(_userRepository.GetById(id)));
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }


    }
}
