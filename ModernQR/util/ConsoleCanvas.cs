using System;

namespace ModernQR
{
    public class ConsoleCanvas : DebugCanvas
    {
        public void Log(String msg)
        {
            Console.WriteLine(msg);
        }
    }
}
