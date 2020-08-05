using FluentValidator;
using ModernStore.Shared.Entities;
using System;

namespace ModernStore.Domain.Entities
{
    public class Customer : Entity
    {
        #region Constructors
        public Customer(string firstName, string lastName, DateTime birthdate, string email, User user)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Email = email;
            User = user;

            new ValidationContract<Customer>(this)
                .IsRequired(x => x.FirstName, "Nome é obrigatório")
                .HasMaxLenght(x => x.FirstName, 60, "Nome possuí um máximo de 60 caracteres")
                .HasMinLenght(x => x.FirstName, 3, "Nome possuí um mínimo de 3 caracteres")
                .IsRequired(x => x.LastName, "Sobrenome é obrigatório")
                .HasMaxLenght(x => x.LastName, 60, "Sobrenome possuí um máximo de 60 caracteres")
                .HasMinLenght(x => x.LastName, 3, "Sobrenome possuí um mínimo de 3 caracteres")
                .IsEmail(x => x.Email, "E-mail inválido");



        }
        #endregion

        #region Properties
        //id e gerenciado pela class entity herdada
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime Birthdate { get; private set; }
        public string Email { get; private set; }
        public User User { get; private set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
        #endregion
    }
}
