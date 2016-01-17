void Main()
{
	Node head = GetLinkedList(length: 19);
	head.Dump();

	GetKthFromLastIterative(head, k: 8).Dump();
	GetKthFromLastRecursive(head, k: 8, item: new IntWrapper()).Dump();
}

public class Node
{
	public int Data { get; set; }
	public Node Next { get; set; }
}

private Node GetLinkedList(int length)
{
	var head = new Node { Data = 0 };

	var runner = head;
	for (int i = 1; i < length; i++)
	{
		runner.Next = new Node { Data = i };
		runner = runner.Next;
	}

	return head;
}

private class IntWrapper
{
	public int Value { get; set; }
}

///<summary>
/// this can be done in two steps
/// 1: move a pointer `runner` till `k` nodes on the list
/// 2: move both `runner` and `kRunner` till `runner` reaches last node, return `kRunner` node
///</summary>
private Node GetKthFromLastIterative(Node head, int k)
{
	if (k <= 0) return null;

	Node runner = head;
	Node kRunner = head;

	for (int i = 0; i < k - 1; i++)
	{
		if (runner == null) return null;

		runner = runner.Next;
	}
	if (runner == null) return null;

	while (runner.Next != null)
	{
		runner = runner.Next;
		kRunner = kRunner.Next;
	}

	return kRunner;
}

///<summary>
///Since IntWrapper is passed by ref, it preserves its state through recursive calls
///on each recursive call, bump `item.Value` and compare with `k` return if there is a match
///</summary>
private Node GetKthFromLastRecursive(Node head, int k, IntWrapper item)
{
	if (head == null) return head;

	Node node = GetKthFromLastRecursive(head.Next, k, item);
	item.Value++;

	if (item.Value == k)
	{
		return head;
	}

	return node;
}