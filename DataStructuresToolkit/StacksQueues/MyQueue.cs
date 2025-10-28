using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.StacksQueues
{
	public class MyQueue<T>
	{
		private T[] _array;
		private int _head;
		private int _tail; 
		private int _count;
		private int _initialCapacity;
		/// <param name="capacity">The initial capacity of the queue.</param>
		public MyQueue(int capacity)
		{
			_initialCapacity = capacity;
			_array = new T[_initialCapacity];
			_head = 0;
			_tail = 0;
			_count = 0;
		}

		/// <summary>
		/// Add an item to the end of the queue.
		/// </summary>
		/// <param name="item">The item to enqueue.</param>
		/// <remarks>o(1) amortized</remarks>
		public void Enqueue(T item)
		{
			if (_count == _array.Length)
			{
				Resize(_array.Length * 2);
			}
				
			_array[_tail] = item;
			_tail = (_tail + 1) % _array.Length;
			_count++;
		}

		/// <summary>
		/// Remove and return the item at the front of the queue.
		/// </summary>
		/// <returns>The item removed from the front of the queue.</returns>
		/// <remarks>o(1) amortized</remarks>
		public T Dequeue()
		{
			if (_count == 0)
			{
				throw new InvalidOperationException("Queue is empty.");
			}
				
			T item = _array[_head];
			_array[_head] = default!;
			_head = (_head + 1) % _array.Length;
			_count--;

			if (_count > 0 && _count == _array.Length / 4)
			{
				Resize(_array.Length / 2);
			}
				
			return item;
		}

		/// <summary>
		/// Return the item at the front of the queue without removing it from the queue.
		/// </summary>
		/// <returns>The item at the front of the queue.</returns>
		/// <remarks>o(1)</remarks>
		public T Peek()
		{
			if (_count == 0)
			{
				throw new InvalidOperationException("Queue is empty.");
			}

			return _array[_head];
		}

		/// <summary>
		/// Get the number of elements in the queue.
		/// </summary>
		/// <remarks>o(1)</remarks>
		public int Count => _count;

		private void Resize(int newSize)
		{
			if (newSize == 0)
			{
				newSize = _initialCapacity;
			}

			T[] newArray = new T[newSize];

			for (int i = 0; i < _count; i++)
			{
				newArray[i] = _array[(_head + i) % _array.Length];
			}
				
			_array = newArray;
			_head = 0;
			_tail = _count;
		}
	}
}
