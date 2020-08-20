using System;
using System.Collections.Generic;
using System.Text;

namespace AtmLibrary
{
    public class Atm
    {
        // injection?
        private readonly IScreen _screen;
        private readonly IKeyPad _keypad;
        private Account _account;

        public Atm(IScreen screen, IKeyPad keypad)
        {
            _screen = screen;
            _keypad = keypad;
        }

        /// <summary>
        /// Start the ATM process
        /// </summary>
        /// <returns>true if successful</returns>
        public bool Start()
        {
            _screen.WriteLine("Welcome. Enter your account number");
            int acct = _keypad.ReadLine();
            _screen.WriteLine("Enter your 4-digit pin code");
            int pin = _keypad.Read(4);
            // _screen.WriteLine($"The account number is {acct}. Pin number is {pin}");
            _account = Account.Fetch(acct, pin);
            if (_account != null)
            {
                return true;
            }
            return false;
        }

        public void Menu()
        {
            Transaction[] transactions = new Transaction[]
            {
                new BalanceInquiry(_screen, _account),
                new Withdrawal(_screen, _keypad, _account),
                new Deposit(_screen, _keypad, _account)
            };
            _screen.WriteLine("Main Menu");
            for (int i = 0; i < transactions.Length; i++)
            {
                _screen.WriteLine($"     {i+1} - {transactions[i].MenuName}");
            }
            //_screen.WriteLine("     1 - View my balance");
            //_screen.WriteLine("     2 - Withdraw cash");
            //_screen.WriteLine("     3 - Deposit funds");
            _screen.WriteLine("     0 - Exit");
            int choice = _keypad.Read(1);
            if (choice == 0)
            {
                // do something here.
                _account = null;
            }
            else if (choice > 0 && choice <= transactions.Length)
            {
                // key value pairs
                Transaction transaction = transactions[choice - 1];
                transaction.Execute();
            }

            transactions[0].Execute();
            Console.ReadLine();
            /*switch(choice) {
                case 1:
                    var balance = new BalanceInquiry(_screen, _account);
                    balance.Execute();
                    break;
                case 2:
                    var withdraw = new Withdrawal(_screen, _keypad, _account);
                    withdraw.Execute();
                    break;
            }*/
        }
    }
}
