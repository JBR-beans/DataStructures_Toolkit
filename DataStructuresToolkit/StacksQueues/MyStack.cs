using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.StacksQueues
{
	public class MyStack<T>
	{
		private T[] _items;
		private int _count;
		private int _initialCapacity;


		public MyStack(int capacity)
		{
			_initialCapacity = capacity;
			_items = new T[_initialCapacity];
			_count = 0;
		}

		/// <summary>
		/// Push an item to the top of the stack.
		/// </summary>
		/// <param name="item">The item to push to the stack.</param>
		/// <remarks>o(1) amortized</remarks>
		public void Push(T item)
		{
			if (_count == _items.Length)
			{
				Resize(_items.Length * 2);
			}

			_items[_count++] = item;
		}
		private void Resize(int newCapacity)
		{
			if (newCapacity < _initialCapacity)
			{
				newCapacity = _initialCapacity;
			}

			T[] newArray = new T[newCapacity];
			Array.Copy(_items, newArray, _count);
			_items = newArray;
		}

		/// <summary>
		/// Remove and return the item at the top of the stack.
		/// </summary>
		/// <returns>The item removed from the top of the stack.</returns>
		/// <remarks>o(1)</remarks>
		public T Pop()
		{
			if (_count == 0)
			{
				throw new InvalidOperationException("Stack is empty.");
			}

			T item = _items[--_count];
			_items[_count] = default(T);

			if (_count > 0 && _count == _items.Length / 4)
			{
				Resize(_items.Length / 2);
			}

			return item;
		}

		/// <summary>
		/// Check what item is at the top of the stack without modifying the stack.
		/// </summary>
		/// <returns>The item at the top of the stack.</returns>
		/// <remarks>o(1)</remarks>
		public T Peek()
		{
			if (_count == 0)
			{
				throw new InvalidOperationException("Stack is empty.");
			}

			return _items[_count - 1];
		}

		/// <summary>
		/// Gets the number of elements in the stack.
		/// </summary>
		/// <remarks>o(1)</remarks>
		public int Count => _count;

	}
}
