using DataStructuresToolkit;
using NUnit.Framework;
using System.Diagnostics;

namespace DataStructuresToolkit.Tests
{
	[TestFixture]
	public class ArrayStringListHelpers_Tests
	{
		private ArrayStringListHelpers helpers;

		[SetUp]
		public void Setup()
		{
			helpers = new ArrayStringListHelpers();
		}

		[Test]
		public void InsertIntoArray_InsertsValueAtCorrectPosition()
		{
			int[] original = { 1, 2, 3, 4 };
			int[] result = helpers.InsertIntoArray(original, 2, 99);
			
			Assert.That(result.Length, Is.EqualTo(5));
			Assert.That(result[2], Is.EqualTo(99));
			Assert.That(result[3], Is.EqualTo(3));
		}

		[Test]
		public void DeleteFromArray_RemovesValueAtCorrectPosition()
		{
			int[] original = { 10, 20, 30, 40 };
			int[] result = helpers.DeleteFromArray(original, 1);

			Assert.That(result.Length, Is.EqualTo(3));
			Assert.That(result[0], Is.EqualTo(10));
			Assert.That(result[1], Is.EqualTo(30));
		}
		[Test]
		public void ConcatenateNamesNaive_ProducesExpectedString()
		{
			string[] names = { "Alice", "Bob", "Charlie" };
			string result = helpers.ConcatenateNamesNaive(names);

			Assert.That(result, Is.EqualTo("AliceBobCharlie"));
		}

		[Test]
		public void ConcatenateNamesBuilder_ProducesExpectedString()
		{
			string[] names = { "Alice", "Bob", "Charlie" };
			string result = helpers.CombineNamesBuilder(names);

			Assert.That(result, Is.EqualTo("AliceBobCharlie"));
		}

		[Test]
		public void InsertIntoList_InsertsCorrectly()
		{
			List<int> list = new List<int> { 1, 2, 3 };
			helpers.InsertIntoList(list, 1, 99);

			Assert.That(list.Count, Is.EqualTo(4));
			Assert.That(list[1], Is.EqualTo(99));
		}

		[Test]
		public void Performance_ConcatenateNamesNaive_Vs_Builder()
		{
			string[] names;

			for (int n = 1000; n <= 10000; n *= 2)
			{
				names = new string[n];
				for (int i = 0; i < n; i++)
					names[i] = "X";

				var swNaive = Stopwatch.StartNew();
				helpers.ConcatenateNamesNaive(names);
				swNaive.Stop();

				var swBuilder = Stopwatch.StartNew();
				helpers.CombineNamesBuilder(names);
				swBuilder.Stop();

				TestContext.WriteLine($"n={n}: Naive={swNaive.ElapsedTicks} ticks, Builder={swBuilder.ElapsedTicks} ticks");

				Assert.That(
					helpers.ConcatenateNamesNaive(new[] { "A", "B" }),
					Is.EqualTo(helpers.CombineNamesBuilder(new[] { "A", "B" }))
				);
			}
		}

		[Test]
		public void Performance_ArrayInsert_Delete_Timing()
		{
			for (int n = 1000; n <= 10000; n *= 2)
			{
				int[] arr = new int[n];
				for (int i = 0; i < n; i++) arr[i] = i;

				var swInsert = Stopwatch.StartNew();
				helpers.InsertIntoArray(arr, n / 2, 999);
				swInsert.Stop();

				var swDelete = Stopwatch.StartNew();
				helpers.DeleteFromArray(arr, n / 2);
				swDelete.Stop();

				TestContext.WriteLine($"n={n}: Insert={swInsert.ElapsedTicks} ticks, Delete={swDelete.ElapsedTicks} ticks");
			}

			Assert.Pass("Performance tests completed successfully.");
		}
	}
}
