#region File Information
/************************************************************
  GetAsmName - (c)WM-data, all rights reserved.

  Name: MainApp.cs
  Created: 2007-03-21

  Author(s):
    Daniel Halan

************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

namespace GetAsmSign {
	
	
	class MainApp {

		private static bool m_SaveToClipboard = false;

		[STAThread]
		static void Main(string[] args) {

			Console.WriteLine("\n=== GetAsmName v1.1 - (c)2007-2014 Daniel Halan ");
      Console.WriteLine("    --------------------------------------------- -- -  -");
			if( args.Length > 0 )  {
				
				// Check for params
				if( args.Length > 1 ) {
					for( int i = 0; i < args.Length - 1; i++ ) {
						if( args[i].Replace("-", "").Equals("c") )
							m_SaveToClipboard = true;
					}
				}
				
				string file = args[args.Length-1];

				if( Path.GetDirectoryName(file).Length == 0 ) {
					file = string.Concat(Directory.GetCurrentDirectory(),'\\',file);
				}

				Assembly asm = System.Reflection.Assembly.LoadFile(file);
				string szName = asm.GetName().FullName;

				Console.WriteLine(szName);

				if( m_SaveToClipboard ) {
					System.Windows.Forms.Clipboard.SetDataObject(szName,true);
					Console.WriteLine("Output saved to clipboard");
				}

        Console.WriteLine("\n");

			} else {
				WriteHelp();
			}

		}


		public static void WriteHelp() {
			Console.WriteLine("Usage: GetAsmName.exe [-c] <assembly file>");
			Console.WriteLine("-c = Save to clipboard (optional)");
		}

	}
}
