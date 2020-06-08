using FluentValidation;
using System;
using User.IO.Rommanel.Domain.Core.Models;

namespace User.IO.Rommanel.Domain.Users
{
    public class User : Entity<User>
    {
        public User(string name,string email, string cpf, DateTime dateBirth, string city,string zipCode,string state)
        {
            Id = new Guid();
            Name = name;
            Email = email;
            DateBirth = dateBirth;
            Cpf = cpf;
            City = city;
            ZipCode = zipCode;
            State = state;
        }
        private User() { }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }      
        public DateTime DateBirth { get; private set; }
        public string City {get; private set; }
        public string ZipCode { get; private set; }
        public string State { get; private set; }

        #region Factory
        public static class UserFactory
        {
            public static User UpdateUser(Guid id,string name, string email, string cpf, DateTime dateBirth, string city, string zipCode, string state)
            {
                var user = new User()
                {
                    Id = id,
                    Name = name,
                    Email = email,
                    DateBirth = dateBirth,
                    Cpf = cpf,
                    City = city,
                    ZipCode = zipCode,
                    State = state

                };

                return user;
            }
        }

        #endregion Factory


        #region Validation

        public override bool IsValid()
        {
            Validate();
            return ValidationResult.IsValid;
        }

        private void Validate()
        {
            ValidateName();
            ValidateEmail();
            ValidateDateBirth();
            ValidateCPF();
            ValidateCity();
            ValidateState();
            ValidateZipCode();
            ValidationResult = Validate(this);

        }
        private void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O nome é obrigatório")
                .Length(2, 150).WithMessage("O nome precisa ter entre 2 e 150 caracteres");
        }
        private void ValidateEmail()
        {
            RuleFor(c => c.Email)
                    .NotEmpty()
                    .WithMessage("Email Obrigatório");

            RuleFor(c => c.Email)
                .EmailAddress()
                .WithMessage("Email Inválido");
        }
        private void ValidateCPF()
        {

            RuleFor(c => c.Cpf).NotEmpty().WithMessage("CPF obrigatório");

            RuleFor(c => c.Cpf).IsValidCPF()
                    .WithMessage("CPF inválido");

        }
        private void ValidateDateBirth()
        {

            RuleFor(c => c.DateBirth.Date)
                     .NotEmpty()
                     .WithMessage("Data de nascimento obrigatório");

            RuleFor(c => c.DateBirth.Date)
                .LessThan(DateTime.Now.Date)
                .WithMessage("A data de nascimento não deve ser maior que a data atual");

        }
        private void ValidateZipCode()
        {
            RuleFor(c => c.ZipCode)
                  .NotEmpty()
                  .WithMessage("CEP obrigatório");

            RuleFor(c => c.ZipCode)
                     .Length(2, 8)
                     .WithMessage("CEP precisa ter entre 2 a 8 numeros");
        }
        private void ValidateCity()
        {
            RuleFor(c => c.City)
                             .NotEmpty()
                             .WithMessage("Cidade obrigatória");

            RuleFor(c => c.City)
               .Length(2, 150)
               .WithMessage("A cidade precisa ter entre 2 e 150 caracteres");
        }
        private void ValidateState()
        {
            RuleFor(c => c.State)
                             .NotEmpty()
                             .WithMessage("Estado obrigatório");

            RuleFor(c => c.State)
               .Length(2, 150)
               .WithMessage("O Estado precisa ter entre 2 e 150 caracteres");
        }

        #endregion
    }
}
