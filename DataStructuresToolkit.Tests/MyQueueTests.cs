using System;
using NUnit.Framework;
using DataStructuresToolkit.StacksQueues;

namespace DataStructuresToolkit.Tests
{
	[TestFixture]
	public class MyQueueTests
	{
		[Test]
		public void Enqueue_IncreasesCountAndPeekReturnsFirst()
		{
			var queue = new MyQueue<int>(2);

			queue.Enqueue(10);
			Assert.That(queue.Count, Is.EqualTo(1));
			Assert.That(queue.Peek(), Is.EqualTo(10));

			queue.Enqueue(20);
			Assert.That(queue.Count, Is.EqualTo(2));
			Assert.That(queue.Peek(), Is.EqualTo(10));
		}

		[Test]
		public void Dequeue_ReturnsFirstEnqueuedAndDecrementsCount()
		{
			var queue = new MyQueue<int>(2);
			queue.Enqueue(1);
			queue.Enqueue(2);

			var first = queue.Dequeue();
			Assert.That(first, Is.EqualTo(1));
			Assert.That(queue.Count, Is.EqualTo(1));

			var second = queue.Dequeue();
			Assert.That(second, Is.EqualTo(2));
			Assert.That(queue.Count, Is.EqualTo(0));
		}

		[Test]
		public void Dequeue_OnEmptyQueue_ThrowsException()
		{
			var queue = new MyQueue<int>(0);
			Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
		}

		[Test]
		public void Peek_OnEmptyQueue_ThrowsException()
		{
			var queue = new MyQueue<int>(0);
			Assert.Throws<InvalidOperationException>(() => queue.Peek());
		}

		[Test]
		public void WraparoundScenario_QueueMaintainsCorrectOrder()
		{
			var queue = new MyQueue<int>(3);

			queue.Enqueue(1);
			queue.Enqueue(2);
			queue.Enqueue(3);

			Assert.That(queue.Dequeue(), Is.EqualTo(1));

			queue.Enqueue(4);

			Assert.That(queue.Dequeue(), Is.EqualTo(2));
			Assert.That(queue.Dequeue(), Is.EqualTo(3));
			Assert.That(queue.Dequeue(), Is.EqualTo(4));

			Assert.That(queue.Count, Is.EqualTo(0));
		}
	}
}
