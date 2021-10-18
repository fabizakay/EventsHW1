using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsHW1
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Account Account { get; set; }
        public bool IsLogin { get; set; }

        public void OnTryLogin(string message)
        {
            Console.WriteLine(message);
        }

        public User()
        {
            Account = new Account();
        }
    }

    public class Account
    {
        public double Balance { get; set; }

        public void WhenDeposit(User u)
        {
            Console.WriteLine($"UserName {u.UserName}. Balance: {u.Account.Balance}");
        }
    }
}

