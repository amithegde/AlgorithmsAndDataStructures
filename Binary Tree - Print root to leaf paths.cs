<Query Kind="Program" />

void Main()
{
	//create tree
	//     1
	//   2   3
	//  4 5 6 7
	//         7
	
	//expected output
	//124, 125, 136, 1377
	
	//1
	var root = new Node(1);
	//2
	root.Left = new Node(2);
	root.Right = new Node(3);
	//3
	root.Left.Left = new Node(4);
	root.Left.Right = new Node(5);
	root.Right.Left = new Node(6);
	root.Right.Right = new Node(7);
	//4
	root.Right.Right.Right = new Node(7);

	LeafToRootPathRecursive(root, new int[100], 0);
}

public class Node
{
	public Node(int data)
	{
		Data = data;
	}

	public int Data { get; set; }
	public Node Left { get; set; }
	public Node Right { get; set; }
}

///<summary>
/// Perform Preorder traversal of the tree while storing the node value for each level
/// print the pat once leaf node is reached
///</summary>
private void LeafToRootPathRecursive(Node root, int[] arr, int level)
{
	if(root == null) return;
	
	arr[level] = root.Data;

	if (root.Left == null && root.Right == null)
	{
		PrintPath(arr, level);
		return; //this return is important
	}
	
	LeafToRootPathRecursive(root.Left, arr, level+1);
	LeafToRootPathRecursive(root.Right, arr, level+1);
}

private void PrintPath(int[] arr, int level)
{
	//note <= level here
	for (int i = 0; i <= level; i++)
	{
		Console.WriteLine(arr[i]);
	};
	
	Console.WriteLine();
}
