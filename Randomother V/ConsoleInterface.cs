using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomother_V
{
	class ConsoleInterface
	{
		public ConsoleInterface()
		{
			//
		}

		public void PrintTitle()
		{
			Console.BackgroundColor = ConsoleColor.Yellow;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.Write("= RANDOMOTHER V ===================================================== ");
			Console.BackgroundColor = ConsoleColor.Red;
			Console.Write("[e] Exit");
			Console.BackgroundColor = ConsoleColor.Yellow;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.WriteLine(" =");
			Console.ResetColor();
		}

		public void MakeCommand()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.Write(" > ");
		}

		public void MakeError()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.BackgroundColor = ConsoleColor.Black;
		}

		public void MakeLol()
		{
			Console.ForegroundColor = ConsoleColor.Black;
			Console.BackgroundColor = ConsoleColor.Blue;
		}
	}
}
