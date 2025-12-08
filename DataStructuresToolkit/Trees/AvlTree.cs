/*
 * While implementing the AVL tree, I identified unbalanced nodes by calculating the balance factor of each node after every insertion. 
 * The balance factor, defined as the height of the left subtree minus the height of the right subtree, revealed when it exceeded 1 or -1, signaling that a rotation was necessary to restore balance.
 * Observing the tree after sequential insertions, it became clear how skewed sequences like ascending or descending values triggered specific rotations to maintain O(log n) height.
 * Comparing rotations in AVL trees to heapify in a priority queue highlighted a key difference in structural guarantees.
 * Rotations maintain strict balance and ordered traversal (in order yields sorted output), while heapify only ensures the heap property (parent >= children for max heap).
 * This makes insertion and removal very fast but doesn't maintain overall sorted order.
 * In a real project, the choice depends on requirements. 
 * If I needed frequent lookups, range queries, or traversals in order, I would choose an AVL tree for its guaranteed O(log n) access and defined ordering.
 * When there are only the largest or smallest element frequently needed and insertions are common, a priority queue would be more efficient and also simpler to maintain. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.Trees
{
	public class AvlTree
	{
		public class AvlNode
		{
			public int Key;
			public AvlNode Left;
			public AvlNode Right;
			public int Height;

			public AvlNode(int key)
			{
				Key = key;
				Height = 1;
			}
		}
		private AvlNode root;

		/// <summary>
		/// Inserts a key into the AVL tree.
		/// Complexity: O(log n)
		/// </summary>
		public void Insert(int key)
		{
			root = Insert(root, key);
		}

		private AvlNode Insert(AvlNode node, int key)
		{
			if (node == null)
			{
				return new AvlNode(key);
			}

			if (key < node.Key)
			{
				node.Left = Insert(node.Left, key);
			}
			else if (key > node.Key)
			{
				node.Right = Insert(node.Right, key);
			}
			else
			{
				return node;
			}

			UpdateHeight(node);
			return Balance(node);
		}

		/// <summary>
		/// Checks if a key exists in the tree.
		/// Complexity: O(log n)
		/// </summary>
		public bool Contains(int key)
		{
			AvlNode current = root;
			while (current != null)
			{
				if (key < current.Key)
				{
					current = current.Left;
				}
				else if (key > current.Key)
				{
					current = current.Right;
				}
				else
				{
					return true;
				}
			}
			return false;
		}

		private int GetHeight(AvlNode node)
		{
			if (node == null)
			{
				return 0;
			}
			else
			{
				return node.Height;
			}
		}

		private void UpdateHeight(AvlNode node)
		{
			int leftHeight = GetHeight(node.Left);
			int rightHeight = GetHeight(node.Right);
			node.Height = 1 + Math.Max(leftHeight, rightHeight);
		}

		private int GetBalanceFactor(AvlNode node)
		{
			int leftHeight = GetHeight(node.Left);
			int rightHeight = GetHeight(node.Right);
			return leftHeight - rightHeight;
		}

		private AvlNode Balance(AvlNode node)
		{
			int balance = GetBalanceFactor(node);

			if (balance > 1)
			{
				if (GetBalanceFactor(node.Left) < 0)
				{
					node.Left = RotateLeft(node.Left);
				}
				return RotateRight(node);
			}

			if (balance < -1)
			{
				if (GetBalanceFactor(node.Right) > 0)
				{
					node.Right = RotateRight(node.Right);
				}
				return RotateLeft(node);
			}

			return node;
		}

		private AvlNode RotateRight(AvlNode y)
		{
			AvlNode x = y.Left;
			AvlNode T2 = x.Right;

			x.Right = y;
			y.Left = T2;

			UpdateHeight(y);
			UpdateHeight(x);

			return x;
		}

		private AvlNode RotateLeft(AvlNode x)
		{
			AvlNode y = x.Right;
			AvlNode T2 = y.Left;

			y.Left = x;
			x.Right = T2;

			UpdateHeight(x);
			UpdateHeight(y);

			return y;
		}

		/// <summary>
		/// Prints the tree keys and balance factors in order.
		/// </summary>
		public void PrintTree()
		{
			PrintTree(root, "", true);
		}

		private void PrintTree(AvlNode node, string indent, bool last)
		{
			if (node != null)
			{
				// https://en.wikipedia.org/wiki/Box-drawing_characters
				Console.WriteLine(indent + (last ? "└ " : "├ ") +
								  node.Key + " (BF=" + GetBalanceFactor(node) + ")");
				if (last)
				{
					indent += "   ";
				}
				else
				{
					indent += "│";
				}
				PrintTree(node.Left, indent, false);
				PrintTree(node.Right, indent, true);
			}
		}
	}
}

