using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.Trees
{
	public class PriorityQueue
	{
		private List<int> heap = new List<int>();

		/// <summary>
		/// Inserts a value into the heap.
		/// Complexity: O(log n)
		/// </summary>
		public void Enqueue(int val)
		{
			heap.Add(val);
			BubbleUp(heap.Count - 1);
		}

		/// <summary>
		/// Removes and returns the smallest value from the heap.
		/// Complexity: O(log n)
		/// </summary>
		public int Dequeue()
		{
			if (heap.Count == 0) throw new InvalidOperationException("Heap is empty");

			int min = heap[0];
			heap[0] = heap[heap.Count - 1];
			heap.RemoveAt(heap.Count - 1);
			BubbleDown(0);
			return min;
		}

		private void BubbleUp(int index)
		{
			int parent = (index - 1) / 2;
			while (index > 0 && heap[index] < heap[parent])
			{
				Swap(index, parent);
				index = parent;
				parent = (index - 1) / 2;
			}
		}
		private void BubbleDown(int index)
		{
			int left, right, smallest;
			while (true)
			{
				left = 2 * index + 1;
				right = 2 * index + 2;
				smallest = index;

				if (left < heap.Count && heap[left] < heap[smallest]) smallest = left;
				if (right < heap.Count && heap[right] < heap[smallest]) smallest = right;
				if (smallest == index) break;

				Swap(index, smallest);
				index = smallest;
			}
		}

		private void Swap(int i, int j)
		{
			int temp = heap[i];
			heap[i] = heap[j];
			heap[j] = temp;
		}

		public void PrintHeap()
		{
			Console.WriteLine(string.Join(", ", heap));
		}
	}
}
