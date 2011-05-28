using System;
using System.Diagnostics;

namespace ModernQR
{
	public class DebugCanvasAdapter : DebugCanvas
	{
		public virtual void  Log(String msg)
		{
            Debug.WriteLine(msg);
		}
	}
}