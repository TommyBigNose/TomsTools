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
				string message = "Cannot set clipboard to null or empty value";
				throw new ArgumentNullException(message);
			}
			Thread thread = new(() => Clipboard.SetText(text, TextDataFormat.Text));
			thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
			thread.Start();
			thread.Join(); //Wait for the thread to end
		}

		public string GetText()
		{
			string text = string.Empty;

			Thread thread = new(() => text = Clipboard.GetText(TextDataFormat.Text));
			thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
			thread.Start();
			thread.Join(); //Wait for the thread to end
			
			return text;
		}
	}
}
