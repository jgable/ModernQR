using System;

namespace ModernQR.Util
{
    public class ConsoleCanvas : DebugCanvas
    {
        public void Log(String msg)
        {
            Console.WriteLine(msg);
        }
    }
}
