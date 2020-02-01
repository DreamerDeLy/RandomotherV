using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomother_V
{
	class Logger
	{
		public string log = "";

		public Logger()
		{
			//
		}

		/// <summary>
		/// Add string to log file
		/// </summary>
		/// <param name="str">String to add (without \r\n)</param>
		public void Add(string str = "")
		{
			log += str + "\r\n";
		}

		public void Clear()
		{
			log = "";
		}
	}
}
