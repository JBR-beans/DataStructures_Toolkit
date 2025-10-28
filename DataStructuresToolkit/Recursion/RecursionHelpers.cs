using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataStructuresToolkit.Recursion
{
	public class RecursionHelpers
	{

		/// <summary>
		/// Calculates the factorial of a non-negative integer n using recursion.
		/// </summary>  
		/// <param name="n">The number to compute factorial for. Must be >= 0.</param>
		/// <returns>The factorial of n.</returns>
		/// <remarks>
		/// Base case: factorial(0) = 1
		/// Recursive step: factorial(n) = n * factorial(n - 1)
		/// Complexity: O(n)
		/// </remarks>
		public static long Factorial(int n)
		{
			if (n < 0)
			{
				throw new ArgumentException("n must be non-negative");
			}

			if (n == 0)
			{
				return 1;
			}

			return n * Factorial(n - 1);
		}


		/// <summary>
		/// Recursively prints all files and folders in a directory and its subdirectories.
		/// </summary>
		/// <param name="directoryPath">The starting directory path.</param>
		/// <param name="indentLevel">Used internally to format output indentation.</param>
		/// <remarks>
		/// Base case: directory has no subdirectories
		/// Recursive step: iterate over subdirectories and call PrintDirectory recursively
		/// Complexity: O(n + m) where n = number of directories, m = number of files
		/// </remarks>
		public static List<string> PrintDirectory(string directoryPath, int indentLevel = 0)
		{

			if (!Directory.Exists(directoryPath))
			{
				throw new DirectoryNotFoundException($"Directory not found: {directoryPath}");
			}
			var result = new List<string>();

			foreach (var dir in Directory.GetDirectories(directoryPath))
			{
				result.AddRange(PrintDirectory(dir, indentLevel + 1));
			}

			return result;
		}

		/// <summary>
		/// Determines whether a given string is a palindrome using recursion.
		/// </summary>
		/// <param name="text">The string to check.</param>
		/// <remarks>
		/// Base case: string length <= 1 (always palindrome)
		/// Recursive step: check first and last characters, then recurse on the substring
		/// Complexity: O(n)
		/// </remarks>

		public static bool IsPalindrome(string text)
		{
			if (string.IsNullOrEmpty(text) || text.Length == 1)
			{
				return true;
			}

			if (text[0] != text[^1])
			{
				return false;
			}

			return IsPalindrome(text.Substring(1, text.Length - 2)); 
		}

	}
}
