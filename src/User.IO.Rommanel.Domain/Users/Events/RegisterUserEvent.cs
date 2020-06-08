using System;
namespace User.IO.Rommanel.Domain.Users.Events
{
    public class RegisterUserEvent: BaseUserEvent
    {
        public RegisterUserEvent(Guid id, string name, string email, string cpf, DateTime dateBirth, string city, string zipCode, string state)
        {
            Id = id;
            Name = name;
            Email = email;
            Cpf = cpf;
            City = city;
            ZipCode = zipCode;
            State = state;
        }
    }
}
