using System;
using System.Collections.Generic;
using System.Text;

namespace AtmLibrary
{
    public class Withdrawal : Transaction
    {
        private readonly Account _account;
        private readonly IScreen _screen;
        private readonly IKeyPad _keypad;

        public Withdrawal(IScreen screen, IKeyPad keypad, Account account)
        {
            _screen = screen;
            _keypad = keypad;
            _account = account;
        }

        public override string MenuName => "Withdraw cash";

        // oop designs
        // prototypes


        public override void Execute()
        {
            _screen.WriteLine("Enter the amount to withdraw");
            decimal cash = _keypad.ReadLine();
            _account.Withdraw(cash);
            _screen.WriteLine("your last transactions was " + (cash * -1).ToString() );
            
        }
    }
}
