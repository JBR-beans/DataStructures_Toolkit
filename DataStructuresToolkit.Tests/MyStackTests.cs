using System;
using NUnit.Framework;
using DataStructuresToolkit.StacksQueues;

namespace DataStructuresToolkit.Tests
{
	[TestFixture]
	public class MyStackTests
	{
		[Test]
		public void Push_IncreasesCountAndPeekReturnsLast()
		{
			var stack = new MyStack<int>(2);

			stack.Push(10);
			Assert.That(stack.Count, Is.EqualTo(1));
			Assert.That(stack.Peek(), Is.EqualTo(10));

			stack.Push(20);
			Assert.That(stack.Count, Is.EqualTo(2));
			Assert.That(stack.Peek(), Is.EqualTo(20));
		}

		[Test]
		public void Pop_ReturnsLastPushedAndDecrementsCount()
		{
			var stack = new MyStack<int>(2);
			stack.Push(1);
			stack.Push(2);

			var popped = stack.Pop();
			Assert.That(popped, Is.EqualTo(2));
			Assert.That(stack.Count, Is.EqualTo(1));

			popped = stack.Pop();
			Assert.That(popped, Is.EqualTo(1));
			Assert.That(stack.Count, Is.EqualTo(0));
		}

		[Test]
		public void Pop_OnEmptyStack_ThrowsException()
		{
			var stack = new MyStack<int>(0);
			Assert.Throws<InvalidOperationException>(() => stack.Pop());
		}

		[Test]
		public void Peek_OnEmptyStack_ThrowsException()
		{
			var stack = new MyStack<int>(0);
			Assert.Throws<InvalidOperationException>(() => stack.Peek());
		}

		[Test]
		public void Push_ResizesUnderRepeatedPush()
		{
			var stack = new MyStack<int>(2);
			for (int i = 0; i < 10; i++)
			{
				stack.Push(i);
			}

			Assert.That(stack.Count, Is.EqualTo(10));
			Assert.That(stack.Peek(), Is.EqualTo(9));
		}
	}
}
