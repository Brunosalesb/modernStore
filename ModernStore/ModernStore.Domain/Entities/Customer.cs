using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Entities
{
    public class Customer
    {
        #region Constructors
        public Customer(string firstName, string lastName, DateTime birthdate, string email, User user)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Email = email;
            User = user;
            Notificantions = new Dictionary<string, string>();

            if (firstName.Length > 3)
                Notificantions.Add("FirstName", "Nome inválido");
            if (lastName.Length > 3)
                Notificantions.Add("LastName", "Sobrenome inválido");
            if (email.Length > 3)
                Notificantions.Add("Email", "Email inválido");
        }
        #endregion

        #region Properties
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime Birthdate { get; private set; }
        public string Email { get; private set; }
        public User User { get; private set; }
        public Dictionary<string, string> Notificantions { get; private set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
        #endregion
    }
}
