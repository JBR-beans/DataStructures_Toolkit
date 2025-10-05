using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataStructuresToolkit
{
	public class ComplexityTester
	{

		/// <summary>
		/// This represents O(1).
		/// </summary>
		/// <param name="input"> Only the first element of the input will be returned. </param>
		/// <remarks>
		/// The complexity is constant, not growing with input size.
		/// </remarks>
		public int RunConstantScenario(int[] input)
		{
			return input[0];
		}

		/// <summary>
		/// This method runs in O(n) time.
		/// </summary>
		/// <param name="input"> The input size, which determines how many operations take place. </param>
		/// <remarks>
		/// Time complexity increases linearly with the input size.
		/// </remarks>
		public int RunLinearScenario(int[] input)
		{
			int count = 0;
			for (int i = 0; i < input.Length; i++)
			{
				count++;
			}
			return count;
		}

		/// <summary>
		/// This represents O(n²).
		/// </summary>
		/// <param name="input"> The input will determine how many operations will take place. </param>
		/// <remarks>
		/// The complexity grows proportionally to the square of the input size.
		/// </remarks>
		public long RunQuadraticScenario(int[] input)
		{
			long combinations = 0;
			for(int i = 0; i < input.Length; i++)
			{
				for(int j = 0; j < input.Length; j++)
				{
					combinations++;
				}
			}
			return combinations;
		}
	}
}
