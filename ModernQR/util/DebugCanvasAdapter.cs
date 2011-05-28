using System;
using System.Diagnostics;

namespace ModernQR.Util
{
	public class DebugCanvasAdapter : DebugCanvas
	{
		public virtual void  Log(String msg)
		{
            Debug.WriteLine(msg);
		}
	}
}