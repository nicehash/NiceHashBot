using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace NiceHashBotLib
{
    public class LibConsole
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();

        public enum TEXT_TYPE
        {
            INFO,
            WARNING,
            ERROR
        };

        public static void OpenConsole()
        {
#if !MONO
            AllocConsole();
#endif
        }

        public static void WriteLine(TEXT_TYPE Type, string Text)
        {
            if (Type == TEXT_TYPE.INFO)
                Console.ForegroundColor = ConsoleColor.White;
            else if (Type == TEXT_TYPE.WARNING)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("[" + DateTime.Now.ToString() + "] " + Type.ToString() + ": " + Text);
        }
    }
}
