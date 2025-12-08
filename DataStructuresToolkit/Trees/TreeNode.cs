using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.Trees
{
	public class TreeNode
	{
		public int Value;
		public TreeNode Left;
		public TreeNode Right;

		public TreeNode(int value)
		{
			Value = value;
		}

		/// <summary>
		/// Builds a teaching tree with nodes: 38, 27, 43, 3, 9
		/// </summary>
		public static TreeNode BuildTeachingTree()
		{
			var root = new TreeNode(38);
			root.Left = new TreeNode(27);
			root.Right = new TreeNode(43);
			root.Left.Left = new TreeNode(3);
			root.Left.Right = new TreeNode(9);
			return root;
		}

		/// <summary>
		/// Inorder traversal (Left, Root, Right)
		/// </summary>
		/// <param name="node">Starting node</param>
		/// <param name="list">List to collect values</param>
		/// <remarks>O(n)</remarks>
		public static void Inorder(TreeNode node, List<int> list)
		{
			if (node == null) return;
			Inorder(node.Left, list);
			list.Add(node.Value);
			Inorder(node.Right, list);
		}

		/// <summary>
		/// Preorder traversal (Root, Left, Right)
		/// </summary>
		public static void Preorder(TreeNode node, List<int> list)
		{
			if (node == null) return;
			list.Add(node.Value);
			Preorder(node.Left, list);
			Preorder(node.Right, list);
		}

		/// <summary>
		/// Postorder traversal (Left, Right, Root)
		/// </summary>
		public static void Postorder(TreeNode node, List<int> list)
		{
			if (node == null) return;
			Postorder(node.Left, list);
			Postorder(node.Right, list);
			list.Add(node.Value);
		}

		/// <summary>
		/// Returns height (number of edges to deepest leaf)
		/// </summary>
		/// <remarks>O(n)</remarks>
		public static int Height(TreeNode node)
		{
			if (node == null) return -1; 
			return 1 + Math.Max(Height(node.Left), Height(node.Right));
		}

		/// <summary>
		/// Returns depth of a node relative to root
		/// </summary>
		public static int Depth(TreeNode root, TreeNode target)
		{
			return DepthHelper(root, target, 0);
		}

		private static int DepthHelper(TreeNode current, TreeNode target, int depth)
		{
			if (current == null) return -1;
			if (current == target) return depth;
			int left = DepthHelper(current.Left, target, depth + 1);
			if (left != -1) return left;
			return DepthHelper(current.Right, target, depth + 1);
		}

	}
}
