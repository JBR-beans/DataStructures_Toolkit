using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit
{
	public class ArrayStringListHelpers
	{
		/// <summary>
		/// Inserts a value into an array at a specified index, shifting elements to the right.
		/// </summary>
		/// <param name="arr">The source array to insert into.</param>
		/// <param name="index">The position where the new value should be inserted.</param>
		/// <param name="value">The value to insert.</param>
		/// <returns>A new array containing the inserted value.</returns>
		/// <remarks>
		/// Time complexity: O(n), because elements after the insertion point must be shifted.
		/// </remarks>
		public int[] InsertIntoArray(int[] arr, int index, int value)
		{
			if (index < 0 || index > arr.Length)
			{
				throw new ArgumentOutOfRangeException(nameof(index));
			}

			int[] result = new int[arr.Length + 1];

			for (int i = 0; i < index; i++)
			{
				result[i] = arr[i];
			}

			result[index] = value;

			for (int i = index; i < arr.Length; i++)
			{
				result[i + 1] = arr[i];
			}
			return result;
		}

		/// <summary>
		/// Deletes an element from an array at a specified index, shifting remaining elements to the left.
		/// </summary>
		/// <param name="arr">The source array to delete from.</param>
		/// <param name="index">The index of the element to delete.</param>
		/// <returns>A new array with the specified element removed.</returns>
		/// <remarks>
		/// Time complexity: O(n), since elements after the deletion point must be shifted.
		/// </remarks>
		public int[] DeleteFromArray(int[] arr, int index)
		{
			if (index < 0 || index >= arr.Length)
			{
				throw new ArgumentOutOfRangeException(nameof(index));
			}

			int[] result = new int[arr.Length - 1];

			for (int i = 0; i < index; i++)
			{
				result[i] = arr[i];
			}
			
			for (int i = index + 1; i < arr.Length; i++)
			{
				result[i - 1] = arr[i];
			}
				
			return result;
		}

		/// <summary>
		/// Combines an array of names into a single string using naive string concatenation.
		/// </summary>
		/// <param name="names">An array of strings to concatenate.</param>
		/// <returns>The concatenated string.</returns>
		/// <remarks>
		/// Time complexity: O(n²) in the worst case, because each concatenation creates a new string.
		/// </remarks>
		public string ConcatenateNamesNaive(string[] names)
		{
			string result = string.Empty;
			for (int i = 0; i < names.Length; i++)
			{
				result += names[i];
			}
			return result;
		}

		/// <summary>
		/// Appends an array of names into a single string using a StringBuilder for efficiency.
		/// </summary>
		/// <param name="names">An array of strings to combine.</param>
		/// <returns>The combined string.</returns>
		/// <remarks>
		/// Time complexity: O(n), because StringBuilder utilizes an internal buffer instead of multiple string copies.
		/// </remarks>
		public string CombineNamesBuilder(string[] names)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < names.Length; i++)
			{
				sb.Append(names[i]);
			}
			return sb.ToString();
		}

		/// <summary>
		/// Inserts a value into a list at a specified position.
		/// </summary>
		/// <param name="list">The list to insert into.</param>
		/// <param name="index">The index where the value will be inserted.</param>
		/// <param name="value">The value to insert.</param>
		/// <remarks>
		/// Time complexity: O(n) for inserting in the middle or beginning, O(1) if inserting at the end.
		/// </remarks>
		public void InsertIntoList(List<int> list, int index, int value)
		{
			if (index < 0 || index > list.Count)
			{
				throw new ArgumentOutOfRangeException(nameof(index));
			}

			list.Insert(index, value);
		}
	}
}

