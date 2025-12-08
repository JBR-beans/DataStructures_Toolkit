using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.HashTables
{
	public class AssociativeHelpers
	{

		public static void Test()
		{
			Console.WriteLine("==| Dictionary Example");
			Console.WriteLine("---");
			Dictionary<string, string> phoneBook = new Dictionary<string, string>
			{
				{ "Alice", "555-1234" },
				{ "Bob", "555-5678" },
				{ "Charlie", "555-9012" }
			};

			Console.WriteLine("Alice's number: " + phoneBook["Alice"]);
			Console.WriteLine("Contains David: " + phoneBook.ContainsKey("David"));
			Console.WriteLine();

			Console.WriteLine("==| HashSet Example");
			Console.WriteLine("---");
			HashSet<string> fruits = new HashSet<string>();

			fruits.Add("apple");
			fruits.Add("banana");
			fruits.Add("apple"); 

			Console.WriteLine("HashSet contents:");
			foreach (string fruit in fruits)
			{
				Console.WriteLine(fruit);
			}
				

			Console.WriteLine("Contains apple: " + fruits.Contains("apple"));
			Console.WriteLine("Contains orange: " + fruits.Contains("orange"));
			Console.WriteLine();
		}

	}
}
