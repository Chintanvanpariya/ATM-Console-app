using System;
using System.Collections.Generic;
using System.Text;

namespace AtmLibrary
{
    public class BalanceInquiry : Transaction
    {
        // delegations - compositions initiated at construction
        private readonly Account _account;
        private readonly IScreen _screen;

        public BalanceInquiry(IScreen screen, Account account)
        {
            _screen = screen;
            _account = account;
        }

        public override string MenuName => "View my balance";

        public override void Execute()
        {
            _screen.WriteLine($"Your account's total balance is {_account.Balance:C}");
        }
    }
}
