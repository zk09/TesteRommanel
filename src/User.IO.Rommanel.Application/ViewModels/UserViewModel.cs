using System;

namespace User.IO.Rommanel.Application.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get;  set; }
        public string Email { get;  set; }
        public DateTime DateBirth { get;  set; }
        public string Cpf { get;  set; }
        public string City { get;  set; }
        public string ZipCode { get;  set; }
        public string State { get;  set; }
    }
}
