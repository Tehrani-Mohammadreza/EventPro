using System;
using Microsoft.AspNetCore.Components;

namespace EventEasePro.Services
{
    public class AuthenticationService
    {
        private string _user;

        public bool IsUserLoggedIn => !string.IsNullOrEmpty(_user);

        public string CurrentUser => _user;

        public void Login(string username)
        {
            _user = username;
        }

        public void Logout()
        {
            _user = null;
        }
    }
}
