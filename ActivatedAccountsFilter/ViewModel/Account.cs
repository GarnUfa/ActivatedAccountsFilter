using System;
using System.Collections.Generic;
using System.Text;

namespace ActivatedAccountsFilter.ViewModel
{
    class Account
    {
        private string _login;
        private string _header;
        public string login {get => _login; set { _login = value; } }
        public string header { get => _header; set { _header = value; } }

        public Account(string login, string header)
        {
            this.login = login;
            this.header = header;
        }
    }
}
