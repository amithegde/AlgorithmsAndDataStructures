void Main()
{
	Node head1 = GetLinkedList();
	Node head2 = GetLinkedList();
	head1.Dump();

	//	O(n) time, < O(n) buffer space
	RemoveDuplicates(head1);
	head1.Dump();
	
	//	O(n^2) time, no buffer
	RemoveDuplicatesNoBuffer(head2);
	head2.Dump();
}

public class Node
{
	public int Data { get; set; }
	public Node Next { get; set; }
}

private Node GetLinkedList()
{
	var head = new Node { Data = 10};
	
	var root = head;
	root.Next = new Node { Data = 11 };
	root = root.Next;
	root.Next = new Node { Data = 12 };
	root = root.Next;
	root.Next = new Node { Data = 11 };
	root = root.Next;
	root.Next = new Node { Data = 13 };
	root = root.Next;
	root.Next = new Node { Data = 12 };
	root = root.Next;
	root.Next = new Node { Data = 10 };
	root = root.Next;
	root.Next = new Node { Data = 14 };
	root = root.Next;
	root.Next = new Node { Data = 14 };

	return head;
}

///<summary>
///iterate over the list, adding each item to a Hashset. If any of the successive item is found on the HashSet,
///remove such item and proceed till end of list
///</summary>
private void RemoveDuplicates(Node head)
{
	if (head == null || head.Next == null)
	{
		return;
	}

	var hashSet = new HashSet<int> { head.Data };

	var prev = head;
	while (prev.Next != null)
	{
		if (hashSet.Contains(prev.Next.Data))
		{
			prev.Next = prev.Next.Next;
		}
		else
		{
			hashSet.Add(prev.Next.Data);
			prev = prev.Next;
		}
	}
}

///<summary>
/// iterate over the list, for each item, check if there exists same item in the list till end,
/// if found, remove such item
///</summary>
private void RemoveDuplicatesNoBuffer(Node head)
{
	if (head == null || head.Next == null)
	{
		return;
	}

	var cur = head;
	while (cur != null && cur.Next != null)
	{
		var next = cur;
		while (next.Next != null)
		{
			if (cur.Data == next.Next.Data)
			{
				next.Next = next.Next.Next;
			}
			else
			{
				next = next.Next;
			}
		}

		cur = cur.Next;
	}
}