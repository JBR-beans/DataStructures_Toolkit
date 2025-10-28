using DataStructuresToolkit.StacksQueues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.DemoHarness
{
	public class Demo_StacksQueues
	{
		public void RunDemo()
		{
			Console.WriteLine("--- MyStack<string> Demo LIFO (Undo sequence) ---");
			var undoStack = new MyStack<string>(4);

			undoStack.Push("Hello");
			undoStack.Push("World");
			undoStack.Push("Hello World");

			Console.WriteLine("Current undo stack (top to bottom):");
			while (undoStack.Count > 0)
			{
				Console.WriteLine($"Undo action: {undoStack.Pop()}");
			}

			Console.WriteLine("\n--- MyQueue<string> Demo FIFO (Print jobs) ---");
			var printQueue = new MyQueue<string>(4);

			printQueue.Enqueue("Document1.pdf");
			printQueue.Enqueue("Document2.docx");
			printQueue.Enqueue("Document3.xlsx");

			Console.WriteLine("Processing print jobs in order:");
			while (printQueue.Count > 0)
			{
				Console.WriteLine($"Printing: {printQueue.Dequeue()}");
			}
		}
	}
}
