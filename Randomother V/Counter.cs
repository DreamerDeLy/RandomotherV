using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomother_V
{
	class Counter
	{
		public List<int> counter = new List<int>() { 0, 0, 0, 0 };
		public int count = 4;

		public Counter(int count = 4)
		{
			SetCount(count);
		}

		public void SetCount(int count)
		{
			this.count = count;
			counter.Clear();

			for (int i = 0; i < count; i++)
			{
				counter.Add(0);
			}
		}

		public void Clear()
		{
			counter.Clear();

			for (int i = 0; i < count; i++)
			{
				counter.Add(0);
			}
		}

		public void AddCount(int player)
		{
			counter[player]++;
		}

		public void SaveToFile(string path)
		{
			//
		}
	}
}
