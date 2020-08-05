using System;

namespace ModernStore.Domain.Entities
{
    public class User
    {
        #region constructors
        public User(string username, string password)
        {
            Id = Guid.NewGuid();
            Username = username;
            Password = password;
            Active = false;
        }
        #endregion

        #region Properties
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }
        #endregion

        #region methods
        public void Activate() => Active = true;
        public void Deactivate() => Active = false;
        #endregion

    }
}
