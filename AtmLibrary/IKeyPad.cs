using System;
using System.Collections.Generic;
using System.Text;

namespace AtmLibrary
{
    public interface IKeyPad
    {
        int ReadLine();
        int Read(int numberOfDigits);
    }
}
