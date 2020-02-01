using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // File

namespace Randomother_V
{
	class Program
	{
		const string PROGRAM = "Randomother V";
		const string VERSION = "0.0.1";

		const string help_path = "res/help.txt";
		const string players_path = "res/players.txt";

		static Logger Log = new Logger();
		static Counter Count = new Counter();

		static RandomGenerator Random = new RandomGenerator(Log, Count, new List<string>() { "Vasya", "Petya", "Vitya", "Kolya" });
		static ConsoleInterface Interface = new ConsoleInterface();

		static void Main(string[] args)
		{
			Console.Title = PROGRAM;
			Log.Add("=== " + PROGRAM + " - " + VERSION  + " ===");
			Log.Add(DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToShortTimeString());
			
			PrintStartDebug();

			Console.ReadKey();
			Console.Clear();

			Interface.PrintTitle();
			Console.WriteLine(File.ReadAllText(help_path)); // Write help
			Console.WriteLine("--------------------------------------------------------------------------------");

			Count.Clear();

			while (true)
			{
				Interface.MakeCommand();
				string cmd = Console.ReadLine();
				Console.ResetColor();
				Command(cmd);
			}
		}

		static void Command(string cmd)
		{
			cmd = cmd.ToLower();
			cmd = cmd.TrimEnd();

			switch (cmd)
			{
				// Commands without arguments
				case "rn":
					Console.WriteLine(Random.RandomNumber());
					break;

				case "rp":
					Console.WriteLine(Random.RandomPlayer());
					break;

				case "log":
					Console.WriteLine(Log.log);
					break;

				case "log_c":
					Log.Clear();
					Log.Add("=== " + PROGRAM + " - " + VERSION + " ===");
					Log.Add(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
					Console.WriteLine("Log cleared!");
					break;

				case "log_s":
					SaveWorkFile(SaveType.Log);
					break;

				case "screen_c":
					Console.Clear();
					Interface.PrintTitle();
					Console.WriteLine(File.ReadAllText(help_path)); // Write help
					Console.WriteLine("--------------------------------------------------------------------------------");
					break;

				case "count":
					for (int i = 0; i < Random.players_number; i++)
					{
						Console.WriteLine(Random.players[i] + " - " + Count.counter[i]);
					}
					break;

				case "count_c":
					Count.Clear();
					Console.WriteLine("Counter cleared!");
					break;

				case "count_s":
					SaveWorkFile(SaveType.Counter);
					break;

				case "lol":
					Interface.MakeLol();
					Console.WriteLine("Lol. Kek. Cheburek.");
					break;

				case "fuck":
					Interface.MakeLol();
					Console.WriteLine("...you");
					break;

				default:
					// Commands with arguments

					if (cmd.StartsWith("m_rn")) //////////////////////////////////////////////////////////////////////////////////////
					{
						try
						{
							int n = Convert.ToInt32(cmd.Substring(5));
							for (int i = 0; i < n; i++)
							{
								Console.WriteLine(Random.RandomNumber());
							}
						}
						catch (Exception e)
						{
							Interface.MakeError();
							Console.WriteLine("! Error with parametr [" + e.ToString() + "]");
						}

					}
					else if (cmd.StartsWith("m_rp")) /////////////////////////////////////////////////////////////////////////////////
					{
						try
						{
							int n = Convert.ToInt32(cmd.Substring(5));
							for (int i = 0; i < n; i++)
							{
								Console.WriteLine(Random.RandomPlayer());
							}

						}
						catch (Exception e)
						{
							Interface.MakeError();
							Console.WriteLine("! Error with parametr \r\n[" + e.ToString() + "]");
						}
					}
					else if (cmd.StartsWith("log_s")) ////////////////////////////////////////////////////////////////////////////////
					{
						try
						{
							string path = cmd.Substring(6);
							SaveWorkFile(SaveType.Log, path);
						}
						catch (Exception e)
						{
							Console.WriteLine("! Error with parametr \r\n[" + e.ToString() + "]");
						}
					}
					else if (cmd.StartsWith("count_s")) //////////////////////////////////////////////////////////////////////////////
					{
						try
						{
							string path = cmd.Substring(8);
							SaveWorkFile(SaveType.Counter, path);
						}
						catch (Exception e)
						{
							Console.WriteLine("! Error with parametr \r\n[" + e.ToString() + "]");
							break;
						}
					}
					else /////////////////////////////////////////////////////////////////////////////////////////////////////////////
					{
						Interface.MakeError();
						Console.WriteLine("! Unknown command");
					}
					break;
			}
		}

		enum SaveType {Log, Counter};

		static void SaveWorkFile(SaveType type, string path = "")
		{
			string file_text = "";

			if (type == SaveType.Counter)
			{
				file_text += "=== " + PROGRAM + " - " + VERSION + " ===" + "\r\n";
				file_text += DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "\r\n";
			}
			
			// MAKE FILE TEXT
			if (type == SaveType.Counter)
			{
				for (int i = 0; i < Count.count; i++)
				{
					file_text += Random.players[i] + " - " + Count.counter[i] + "\r\n";
				}
			}
			else if (type == SaveType.Log)
			{
				file_text += Log.log;
			}

			// SAVE TO FILE
			try
			{
				if (path == "")
				{
					string date = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.Hour + "." + DateTime.Now.Minute + "." + DateTime.Now.Second + "." + DateTime.Now.Millisecond;

					if (type == SaveType.Counter) path = "counter-" + date + ".txt";
					else if (type == SaveType.Log) path = "log-" + date + ".txt";
				}

				if (File.Exists(path))
				{
					File.AppendAllText(path, "\r\n" + file_text);
				}
				else
				{
					File.AppendAllText(path, file_text);
				}

				Console.WriteLine("File saved - " + path);
			}
			catch (Exception e)
			{
				Console.WriteLine("! Error while saving file \r\n[" + e.ToString() + "]");
			}
		}

		static void PrintStartDebug()
		{
			Console.WriteLine("Players:");
			for (int i = 0; i < Random.players.Count; i++)
			{
				Console.WriteLine(Random.players.ElementAt(i));
			}
			Console.WriteLine();

			Console.WriteLine("Counter:");
			for (int i = 0; i < Count.count; i++)
			{
				Console.WriteLine(Count.counter.ElementAt(i));
			}
			Console.WriteLine();

			Console.WriteLine("Random:");
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(Random.RandomPlayer(false));
			}
			Console.WriteLine();
		}
	}
}
