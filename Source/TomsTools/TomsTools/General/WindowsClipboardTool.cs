using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomsTools.General
{
	public class WindowsClipboardTool : IClipboardTool
	{
		public void SetText(string text)
		{
			//Clipboard.SetText(text);
			Thread thread = new(() => Clipboard.SetText(text));
			thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
			thread.Start();
			thread.Join(); //Wait for the thread to end
		}
	}
}
