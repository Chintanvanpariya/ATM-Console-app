using AtmLibrary;
using System;

namespace AtmProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var screen = new ConsoleScreen();
            var keypad = new ConsoleKeyPad();
            
            var atm = new Atm(screen, keypad);
            if (atm.Start())
            {
                screen.WriteLine("Logged in");
                while (true)
                {

                    atm.Menu();
                }

            }

        }
    }
}
