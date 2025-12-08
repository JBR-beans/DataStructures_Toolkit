using DataStructuresToolkit.HashTables;
using DataStructuresToolkit.Trees;

namespace DataStructuresConsole
{
	internal class Program
	{
		static void Main(string[] args)
		{
			SimpleHashTable.Test();
			AssociativeHelpers.Test();
			TeachingTreeTraversals();
			AVLTests();

		}

		public static void AVLTests()
		{
			Console.WriteLine("AVL Tree Tests:");
			AvlTree avl = new AvlTree();
			int[] avlValues = { 10, 20, 5, 4, 15 };

			foreach (int val in avlValues)
			{
				avl.Insert(val);
			}

			avl.PrintTree();
			Console.WriteLine("Contains 15? " + avl.Contains(15)); // True
			Console.WriteLine("Contains 100? " + avl.Contains(100)); // False

			// ----- Priority Queue -----
			Console.WriteLine("\nPriority Queue Tests:");
			PriorityQueue pq = new PriorityQueue();
			int[] pqValues = { 20, 5, 15, 10 };

			foreach (int val in pqValues)
			{
				pq.Enqueue(val);
			}

			Console.WriteLine("Heap contents:");
			pq.PrintHeap();

			Console.WriteLine("Dequeue order:");
			while (true)
			{
				try
				{
					Console.WriteLine(pq.Dequeue());
				}
				catch
				{
					break;
				}
			}
		}
		public static void TeachingTreeTraversals()
		{
			Console.WriteLine("Teaching Tree Traversals");
			TreeNode teachingTree = TreeNode.BuildTeachingTree();
			List<int> inorder = new List<int>();
			List<int> preorder = new List<int>();
			List<int> postorder = new List<int>();

			TreeNode.Inorder(teachingTree, inorder);
			TreeNode.Preorder(teachingTree, preorder);
			TreeNode.Postorder(teachingTree, postorder);

			Console.WriteLine("Inorder: " + string.Join(", ", inorder));
			Console.WriteLine("Preorder: " + string.Join(", ", preorder));
			Console.WriteLine("Postorder: " + string.Join(", ", postorder));
			Console.WriteLine("Height of teaching tree: " + TreeNode.Height(teachingTree));
			Console.WriteLine();

			Console.WriteLine("BST Lecture Sequence");
			Bst bst = new Bst();
			int[] lectureSequence = { 50, 30, 70, 20, 40, 60, 80 };
			Console.Write("Inserted values: ");
			Console.WriteLine(string.Join(", ", lectureSequence));
			foreach (int val in lectureSequence)
			{
				bst.Insert(val);
			}

			Console.WriteLine("Contains 60: " + bst.Contains(60));
			Console.WriteLine("Contains 25: " + bst.Contains(25));
			Console.WriteLine("BST Height: " + bst.Height());
			Console.WriteLine();

			Console.WriteLine("Skewed BST (sorted insertions)");
			Bst skewedBst = new Bst();
			int[] sortedSequence = { 10, 20, 30, 40, 50 };
			Console.Write("Inserted values: ");
			Console.WriteLine(string.Join(", ", sortedSequence));
			foreach (int val in sortedSequence)
			{
				skewedBst.Insert(val);
			}
			Console.WriteLine("Skewed BST Height: " + skewedBst.Height());
		}
	}
}
