using System;

namespace User.IO.Rommanel.Domain.Users.Commands
{
    public class RegisterUserCommand: BaseUserCommand
    {
        public RegisterUserCommand(string name, string email, string cpf, DateTime dateBirth, string city, string zipCode, string state)
        {
            Id = new Guid();
            Name = name;
            Email = email;
            Cpf = cpf;
            City = city;
            ZipCode = zipCode;
            State = state;
        }
    }
}
