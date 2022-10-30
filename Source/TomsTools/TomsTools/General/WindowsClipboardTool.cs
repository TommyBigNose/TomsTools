using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TomsTools.General
{
	public class WindowsClipboardTool : IClipboardTool
	{
		public void SetText(string text)
		{
			if(string.IsNullOrEmpty(text))
			{
				throw new ArgumentNullException("Cannot set clipboard to null or empty value");
			}
			Thread thread = new(() => Clipboard.SetText(text));
			thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
			thread.Start();
			thread.Join(); //Wait for the thread to end
		}

		public string GetText()
		{
			string text = string.Empty;

			Thread thread = new(() => text = Clipboard.GetText());
			thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
			thread.Start();
			thread.Join(); //Wait for the thread to end
			
			return text;
		}
	}
}
