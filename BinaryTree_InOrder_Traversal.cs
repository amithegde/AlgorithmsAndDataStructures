void Main()
{
	//create tree
	//     1
	//   2   3
	//  4 5 6 7
	//         8

	//expected output
	//4 2 5 1 6 3 7 8

	/*
	 * Recursive Algorithm: 
	 * 1: Traverse left subtree of node `root`
	 * 2: Process node `root`
	 * 3: Traverse right subtree of node `root`
	*/

	/*
	 * Iterative Algorithm: 
	 * 1: Push left nodes from root to left most node in to a stack
	 * 2: If stack is empty, break out of the loop
	 * 3: Pop the top item from stack, process it and start traversing its right subtree
	*/
	
	Node root = GetTree();
	InOrderTraversalRecursive(root);
	Console.WriteLine();
	InOrderTraversalIterative(root);
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

private Node GetTree()
{
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
	root.Right.Right.Right = new Node(8);
	
	return root;
}

private void InOrderTraversalRecursive(Node root)
{
	//base case
	if(root == null) return;
	
	InOrderTraversalRecursive(root.Left);
	
	Console.Write(root.Data + " ");
	
	InOrderTraversalRecursive(root.Right);
}

private void InOrderTraversalIterative(Node root)
{
	if(root == null) return;
	
	var stack = new Stack<Node>();
	
	while (true)
	{
		while (root != null)
		{
			stack.Push(root);
			root = root.Left;
		}

		if (stack.Count <= 0) break;
	
		root = stack.Pop();
		Console.Write(root.Data + " ");
		root = root.Right;
	}
}