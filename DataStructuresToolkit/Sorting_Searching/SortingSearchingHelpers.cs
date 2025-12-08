using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.Sorting_Searching
{
	public class SortingSearchingHelpers
	{

		public int LinearSearch(int[] arr, int target)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i] == target)
				{
					return i;
				}
			}
			return -1;
		}

		public int BinarySearch(int[] arr, int target)
		{
			int left = 0;
			int right = arr.Length - 1;

			while (left <= right)
			{
				int mid = (left + right) / 2;

				if (arr[mid] == target)
				{
					return mid;
				}
				else if (arr[mid] < target)
				{
					left = mid + 1;
				}
				else
				{
					right = mid - 1;
				}
			}

			return -1;
		}
		public void BubbleSort(int[] arr)
		{
			bool swapped;

			for (int i = 0; i < arr.Length - 1; i++)
			{
				swapped = false;

				for (int j = 0; j < arr.Length - 1 - i; j++)
				{
					if (arr[j] > arr[j + 1])
					{
						int temp = arr[j];
						arr[j] = arr[j + 1];
						arr[j + 1] = temp;
						swapped = true;
					}
				}

				if (!swapped)
				{
					break;
				}
			}
		}
		public void MergeSort(int[] arr)
		{
			if (arr.Length <= 1)
			{
				return;
			}

			int mid = arr.Length / 2;
			int[] left = new int[mid];
			int[] right = new int[arr.Length - mid];

			Array.Copy(arr, 0, left, 0, mid);
			Array.Copy(arr, mid, right, 0, arr.Length - mid);

			MergeSort(left);
			MergeSort(right);

			Merge(arr, left, right);
		}

		private void Merge(int[] arr, int[] left, int[] right)
		{
			int i = 0;
			int j = 0;
			int k = 0;

			while (i < left.Length && j < right.Length)
			{
				if (left[i] <= right[j])
				{
					arr[k] = left[i];
					i++;
				}
				else
				{
					arr[k] = right[j];
					j++;
				}
				k++;
			}

			while (i < left.Length)
			{
				arr[k] = left[i];
				i++;
				k++;
			}

			while (j < right.Length)
			{
				arr[k] = right[j];
				j++;
				k++;
			}
		}
	}
}
