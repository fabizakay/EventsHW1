using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsHW1
{
    public delegate void SendMessage(string message);
    public delegate void DepositMoney(User user);

    class Bank
    {
        List<User> users = new List<User>();
        public event SendMessage SuccessLogin;
        public event SendMessage UnsuccessLogin;
        public event DepositMoney BalanceChanged;

        public Bank()
        {
            users.Add(new User { UserName = "11", Password = "22" });
            users.Add(new User { UserName = "33", Password = "acdsc" });
            users.Add(new User { UserName = "44", Password = "2fs" });
        }
        public User Login(string userName, string password)
        {
            User user = users.FirstOrDefault(usr => usr.UserName == userName);
            if (user != null)
            {
                if (user.Password == password)
                {
                    OnLoginSuccess("Login Success");
                    user.IsLogin = true;
                    return user;
                }
                else
                {
                    OnLoginFailed("Password Not Exists");
                    return null;
                }
            }
            else
            {
                OnLoginFailed("User Name Not Exists");
                return null;
            }
        }

        public void Deposit(User user, double amount)
        {
            if (user != null && user.IsLogin)
            {
                user.Account.Balance += amount;
                OnMoneyDeposited(user);
            }
        }

        private void OnLoginFailed(string message)
        {
            UnsuccessLogin?.Invoke(message);
        }

        private void OnLoginSuccess(string message)
        {
            SuccessLogin?.Invoke(message);
        }

        private void OnMoneyDeposited(User user)
        {
            BalanceChanged?.Invoke(user);
        }
    }
}
