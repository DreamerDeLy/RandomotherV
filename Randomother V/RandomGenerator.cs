using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomother_V
{
	class RandomGenerator
	{
		public int players_number = 1;
		public List<string> players = new List<string>() {"Vasya", "Petya", "Vitya", "Kolya"};

		static Random random = new Random();
		Logger Log;
		Counter Count;

		public RandomGenerator(Logger Log, Counter Count, List<string> players)
		{
			this.Log = Log;
			this.Count = Count;
			this.players = players;
			players_number = players.Count;
		}

		public void SetPlayers(List<string> new_players)
		{
			players = new_players;
			players_number = players.Count;

			Count.Clear();
		}

		public string RandomPlayer(bool logging = true)
		{
			int r_n = random.Next(players_number);
			string r_player = players.ElementAt(r_n);

			Count.AddCount(r_n);

			if (logging) Log.Add(r_player);

			return r_player;
		}

		public int RandomNumber(bool logging = true)
		{
			int r_number = random.Next(players_number)+1;
			if (logging) Log.Add(r_number.ToString());

			return r_number;
		}		
	}	
}
