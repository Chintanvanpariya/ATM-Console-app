using System;
using System.Collections.Generic;
using System.Text;

namespace AtmLibrary
{
    public class Deposit : Transaction
    {
        private readonly Account _account;
        private readonly IScreen _screen;
        private readonly IKeyPad _keypad;

        public Deposit(IScreen screen, IKeyPad keypad, Account account)
        {
            _screen = screen;
            _keypad = keypad;
            _account = account;
        }

        public override string MenuName => "Deposit Cash";

        // oop designs
        // prototypes


        public override void Execute()
        {
            _screen.WriteLine("Enter the amount to deposit");
            decimal cash = _keypad.ReadLine();
            _account.Deposit(cash);
            _screen.WriteLine("your last transactions was: +" + cash.ToString() );
        }
    }
}
