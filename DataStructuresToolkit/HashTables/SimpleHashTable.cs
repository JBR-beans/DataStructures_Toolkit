/*
Reflection:

I learned how hash tables store data in buckets determined by a hash function, and what happens when multiple keys have a collision. 
In SimpleHashTable, collisions are handled using chaining, where each bucket contains a 
list of all keys that hash to that index. This way, no data is lost, though lookup and insertion 
operations require scanning the list, which can degrade performance if too many keys collide.

Using the built in containers like Dictionary and HashSet simplifies things significantly. 
Dictionary manages hashing and collisions internally, providing fast lookups, insertions, and automatic 
resizing without requiring manual bucket management. HashSet similarly prevents duplicates efficiently 
while hiding the underlying implementation details. These classes save development time and reduce the 
likelihood of errors, making them ideal for most production ready solutions.

Despite the benefits of the built in implementations, there are scenarios where implementing a custom hash table 
is advantageous. For example, when granular control over hashing behavior, memory allocation, or 
performance optimizations is needed, a custom implementation can be tailored to a specific use case. 
Additionally, building a hash table from scratch is a great educational exercise, as it helps 
developers understand fundamental data structure concepts, collision handling strategies, and algorithms.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.HashTables
{

	/// <summary>
	/// Initializes a new instance of the SimpleHashTable class.
	/// </summary>
	/// <param name="size">The number of buckets in the hash table.</param>
	public class SimpleHashTable
	{
		private List<int>[] buckets;

		public SimpleHashTable(int size)
		{
			buckets = new List<int>[size];
		}

		public static void Test()
		{

			SimpleHashTable sht = new SimpleHashTable(5);

			sht.Insert(12);
			sht.Insert(22);
			sht.Insert(37);

			Console.WriteLine("==| Hash Table Contents");
			Console.WriteLine("---");
			sht.PrintTable();
			Console.WriteLine("\n==| Tests");
			Console.WriteLine("---");
			Console.WriteLine("Contains(12): " + sht.Contains(12));
			Console.WriteLine("Contains(22): " + sht.Contains(22));
			Console.WriteLine("Contains(37): " + sht.Contains(37));
			Console.WriteLine("Contains(5): " + sht.Contains(5));
		}
		private int Hash(int key)
		{
			return key % buckets.Length;
		}
		/// <summary>
		/// Inserts a key into the hash table.
		/// </summary>
		/// <param name="key">The key to insert.</param>
		/// <remarks>
		/// Average case: O(1), Worst case: O(n) (if many keys collide in the same bucket)
		/// </remarks>

		public void Insert(int key)
		{
			int index = Hash(key);


			if (buckets[index] == null)
			{
				buckets[index] = new List<int>();
			}

			if (!buckets[index].Contains(key))
			{
				buckets[index].Add(key);
			}
		}

		/// <summary>
		/// Checks if the hash table contains a specific key.
		/// </summary>
		/// <param name="key">The key to check.</param>
		/// <returns>True if the key exists, otherwise false.</returns>
		/// <remarks>
		/// Average case: O(1), Worst case: O(n) (if many keys collide in the same bucket)
		/// </remarks>

		public bool Contains(int key)
		{
			int index = Hash(key);
			return buckets[index] != null && buckets[index].Contains(key);
		}

		/// <summary>
		/// Prints the contents of all buckets in the hash table.
		/// </summary>
		/// <remarks> 
		/// Time complexity: O(n)
		/// </remarks>
		public void PrintTable()
		{
			for (int i = 0; i < buckets.Length; i++)
			{
				Console.Write($"Bucket {i}: ");

				if (buckets[i] != null)
				{
					foreach (int key in buckets[i])
					{
						Console.Write(key + " ");
					}
				}

				Console.WriteLine();
			}
		}
	}
}
