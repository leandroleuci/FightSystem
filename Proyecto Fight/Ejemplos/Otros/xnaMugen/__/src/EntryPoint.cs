﻿using System;
using Microsoft.Xna.Framework;

namespace xnaMugen
{
	/// <summary>
	/// Class holding entry point into program.
	/// </summary>
	static class EntryPoint
	{
		/// <summary>
		/// Where the program starts. Starts logging if necessary and runs game loop.
		/// </summary>
		static void Main()
		{
#if TEST
			using (Game g = new MugenTest()) g.Run();
#elif DEBUG
			Log.Start(); 
			using (Game g = new Mugen()) g.Run();
#else
			try
			{
				Log.Start();
				using (Game g = new Mugen()) g.Run();
			}
			catch (Exception e)
			{
				Log.WriteException(e);

				System.Windows.Forms.MessageBox.Show(e.ToString(), "xnaMugen");
			}
#endif
		}
	}
}