using System;
using System.Collections.Generic;
using System.Text;

namespace AtmLibrary
{
    public class Account
    {
        public int AccountNumber { get; }

        private int _pin;

        private decimal _balance;

        public string lasttransac;

        public decimal Balance { get { return _balance; } }

        public Account(int accountNumber, int pin, decimal balance)
        {
            AccountNumber = accountNumber;
            _pin = pin;
            _balance = balance;
        }

        public bool ValidatePin(int pin)
        {
            return pin == _pin;
        }

        public bool Withdraw(decimal amount)
        {
            _balance -= amount;
            return true;
        }

        public bool Deposit(decimal amount)
        {
            _balance += amount;
            return true;
        }
        /// <summary>
        /// Fetch an account using an account number and a pin
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="pin"></param>
        /// <returns>account or null if not found / bad pin</returns>
        public static Account Fetch(int accountNumber, int pin)
        {
            foreach (Account account in _database)
            {
                if (accountNumber == account.AccountNumber)
                {
                    if (account.ValidatePin(pin))
                    {
                        return account;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return null;
        }

        private static readonly List<Account> _database = new List<Account>() {
            new Account(1313, 7890, 10000m),
            new Account(1212, 987, 1000m)
          };
    }
}
