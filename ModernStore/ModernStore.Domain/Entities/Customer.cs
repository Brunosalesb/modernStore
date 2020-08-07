using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Entities;
using System;

namespace ModernStore.Domain.Entities
{
    public class Customer : Entity
    {
        #region Constructors
        public Customer(Name name, Email email, Document document, User user)
        {
            Name = name;
            Email = email;
            Document = document;
            User = user;

            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(document.Notifications);
        }
        #endregion

        #region Properties
        //id e gerenciado pela class entity herdada
        public Name Name { get; private set; }
        public DateTime Birthdate { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }
        public User User { get; private set; }
        #endregion

        #region Methods

        public void Update(Name name, DateTime birthDate)
        {
            Name = name;
            Birthdate = birthDate;
        }
        #endregion
    }
}
