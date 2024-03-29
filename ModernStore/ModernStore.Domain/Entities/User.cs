﻿using FluentValidator;
using ModernStore.Shared.Entities;
using System;
using System.Text;

namespace ModernStore.Domain.Entities
{
    public class User : Entity
    {
        #region constructors
        //por conta do EF, as entidades precisam ter um ctor vazio(uso protected par nao ser corruptivel)
        protected User() { }
        public User(string username, string password, string confirmPassword)
        {
            Username = username;
            Password = EncryptPassword(password);
            Active = true;

            new ValidationContract<User>(this)
                .AreEquals(x => x.Password, EncryptPassword(confirmPassword), "As senhas não coincidem");
        }
        #endregion

        #region Properties
        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }
        #endregion

        #region methods
        public void Activate() => Active = true;
        public void Deactivate() => Active = false;
        private string EncryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return "";
            var password = (pass += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }
        #endregion

    }
}
