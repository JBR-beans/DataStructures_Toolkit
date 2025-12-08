

/*
 * Tree traversal really changes how you understand the tree. Inorder traversal (Left, Root, Right) shows the values in sorted order, which is helpful for checking BST correctness.
 * Preorder (Root, Left, Right) emphasizes the structure from the top down, so you can see how the tree is built and understand parent child relationships.
 * Postorder (Left, Right, Root) visits children before the parent, which is useful for operations like deleting nodes or evaluating expressions.
 * Each traversal gives a slightly different perspective on the same tree, so using all three helps you get a full picture.
 * Height is the number of edges from a node to its deepest leaf, and it directly affects efficiency.
 * In a BST, search, insertion, and deletion take time proportional to height (O(h)).
 * A shorter tree means faster operations, while a taller tree slows things down.
 * Balanced versus skewed insertions really show this difference.
 * If you insert nodes in a random or balanced order, the tree stays short, keeping operations fast.
 * If you insert sorted values, the tree becomes skewed, essentially like a linked list, and searches or inserts can take linear time.
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructuresToolkit.Trees
{
	public class Bst
	{
		public TreeNode Root;

		/// <summary>
		/// Inserts a value into the BST
		/// </summary>
		/// <remarks>O(h)</remarks>
		public void Insert(int value)
		{
			if (Root == null)
			{
				Root = new TreeNode(value);
			}
			else
			{
				Insert(Root, value);
			}
		}

		private void Insert(TreeNode current, int value)
		{
			if (value < current.Value)
			{
				if (current.Left == null)
				{
					current.Left = new TreeNode(value);
				}
				else
				{
					Insert(current.Left, value);
				}
			}
			else if (value > current.Value)
			{
				if (current.Right == null)
				{
					current.Right = new TreeNode(value);
				}
				else
				{
					Insert(current.Right, value);
				}
			}
		}

		/// <summary>
		/// Determines if a value exists in the BST
		/// </summary>
		/// <remarks>O(h)</remarks>
		public bool Contains(int value)
		{
			return Contains(Root, value);
		}

		private bool Contains(TreeNode current, int value)
		{
			if (current == null)
			{
				return false;
			}

			if (current.Value == value)
			{
				return true;
			}
			else if (value < current.Value)
			{
				return Contains(current.Left, value);
			}
			else
			{
				return Contains(current.Right, value);
			}
		}

		/// <summary>
		/// Returns height of the BST
		/// </summary>
		public int Height()
		{
			return TreeNode.Height(Root);
		}
	}
}
