using DataStructuresToolkit;
using NUnit.Framework;
using System.Diagnostics;

namespace DataStructuresToolkit.Tests
{
	public class ComplexityTester_Tests
	{
		private int[][] arrays = new int[3][];
		private ComplexityTester tester = new ComplexityTester();

		[SetUp]
		public void Setup()
		{
			arrays[0] = new int[1000];
			arrays[1] = new int[10000];
			arrays[2] = new int[100000];
		}

		[Test]
		public void RunConstantScenario_ReturnsFirstElement()
		{
			var sw = new Stopwatch();
			for (int i = 0; i < arrays.Length; i++)
			{
				int expectedValue = 0;
				sw.Start();
				int result = tester.RunConstantScenario(arrays[i]);
				sw.Stop();
				TestContext.WriteLine($"n={arrays[i].Length}: {sw.ElapsedMilliseconds} ms");
				sw.Reset();
				Assert.That(result, Is.EqualTo(expectedValue));
			}
		}

		[Test]
		public void RunLinearScenario_CountsElements()
		{
			var sw = new Stopwatch();
			for (int i = 0; i < arrays.Length; i++)
			{
				int expectedValue = arrays[i].Length;
				sw.Start();
				int result = tester.RunLinearScenario(arrays[i]);
				sw.Stop();
				TestContext.WriteLine($"n={arrays[i].Length}: {sw.ElapsedMilliseconds} ms");
				sw.Reset();
				Assert.That(result, Is.EqualTo(expectedValue));
			}
		}

		[Test]
		public void RunQuadraticScenario_CountsCombinations()
		{
			var sw = new Stopwatch();
			for (int i = 0; i < arrays.Length; i++)
			{
				long expectedValue = (long)arrays[i].Length * (long)arrays[i].Length;
				sw.Start();
				long result = tester.RunQuadraticScenario(arrays[i]);
				sw.Stop();
				TestContext.WriteLine($"n={arrays[i].Length}: {sw.ElapsedMilliseconds} ms");
				sw.Reset();
				Assert.That(result, Is.EqualTo(expectedValue));
			}
		}
	}
}
