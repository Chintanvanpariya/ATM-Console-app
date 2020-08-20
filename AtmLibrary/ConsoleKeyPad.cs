using System;
using System.Collections.Generic;
using System.Text;

namespace AtmLibrary
{
    public class ConsoleKeyPad : IKeyPad
    {
        public int ReadLine()
        {
            string line = Console.ReadLine();
            return int.Parse(line);
        }

        public int Read(int numberOfDigits)
        {
            int num = 0;
            int digit = 1;
            if (numberOfDigits > 10) numberOfDigits = 10;
            for (int i = 0; i < numberOfDigits - 1; i++)
            {
                digit *= 10;
            }

            while (digit > 0)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.KeyChar >= '0' && key.KeyChar <= '9')
                {
                    num = num + digit * (key.KeyChar - '0');
                    digit = digit / 10;
                }
            }
            Console.WriteLine();
            return num;
        }
    }
}
