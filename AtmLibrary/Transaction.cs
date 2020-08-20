using System;
using System.Collections.Generic;
using System.Text;

namespace AtmLibrary
{
    public abstract class Transaction
    {
        public abstract void Execute();

        public abstract string MenuName { get; }
    }
}
