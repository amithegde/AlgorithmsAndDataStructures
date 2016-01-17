<Query Kind="Program" />

void Main()
{
	int[] arr = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

	Console.WriteLine("Index: " + BinarySearchIterative(arr, start: 0, end: arr.Length - 1, num: 8));
	Console.WriteLine("Index: " + BinarySearchRecursive(arr, start: 0, end: arr.Length - 1, num: 8));
	
	/*
	 * mid is calculated by using formula `start + ((end - start) / 2)` to avoid integer overflow
	 * Ref: http://googleresearch.blogspot.com/2006/06/extra-extra-read-all-about-it-nearly.html
	 */
}

private int BinarySearchIterative(int[] arr, int start, int end, int num)
{
	while (start <= end)
	{
		int mid = start + ((end - start) / 2);
		if (arr[mid] == num) return mid;
		
		//if num is greater, search on the right half, else on the left half
		if (arr[mid] < num)
		{
			start = mid + 1;
		}
		else
		{
			end = mid - 1;
		}
	}

	return -1;
}

private int BinarySearchRecursive(int[] arr, int start, int end, int num)
{
	if (end >= start)
	{
		int mid = start + ((end - start) / 2);
		if (arr[mid] == num) return mid;
		
		//if num is greater, search on the right half
		if (arr[mid] < num) return BinarySearchRecursive(arr, mid + 1, end, num);
		
		//if num is lesser, search on the left half
		return BinarySearchRecursive(arr, start, mid - 1, num);
	}

	return -1;
}