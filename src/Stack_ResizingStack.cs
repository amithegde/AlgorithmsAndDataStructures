void Main()
{
	//Auto Resizing Stack
	var stack = new ResizingStack();

	stack.Push("1");
	stack.Push("2");
	stack.Push("3");

	Console.WriteLine("\nsize: " + stack.Size + " Capacity: " + stack.StackCapacity);

	stack.Push("4");
	stack.Push("5");
	stack.Push("6");

	Console.WriteLine("\nsize: " + stack.Size + " Capacity: " + stack.StackCapacity);

	Console.WriteLine("\nPop elements");
	Console.WriteLine(stack.Pop());
	Console.WriteLine(stack.Pop());
	Console.WriteLine(stack.Pop());

	Console.WriteLine("\nsize: " + stack.Size + " Capacity: " + stack.StackCapacity);

	Console.WriteLine(stack.Pop());
	Console.WriteLine(stack.Pop());
	Console.WriteLine(stack.Pop());

	Console.WriteLine("\nsize: " + stack.Size + " Capacity: " + stack.StackCapacity);
}

public class ResizingStack
{
	private Object[] array = null;
	private int top;

	public ResizingStack()
	{
		array = new Object[2];
		top = -1;
	}

	public bool ISEmpty { get { return top == -1; } }

	public int Size { get {return top + 1;} }

	public int StackCapacity { get {return array.Length; } }

	public void Push(Object item)
	{
		if (array.Length == top + 1)
		{
			ResizeStack(array.Length * 2);
		}
		array[++top] = item;
	}

	public Object Pop()
	{
		if (top == -1)
		{
			return null;
		}

		var item = array[top];
		array[top--] = null;
		if (top > 0 && top <= array.Length / 4)
		{
			ResizeStack(array.Length / 2);
		}

		return item;
	}
	
	///<summary>
	/// creates a new array of size `length`, copies over elements from the array which maintains stack,
	/// and replaces the original array with resized array
	///<summary>
	private void ResizeStack(int length)
	{
		if (length <= 0)
		{
			length = 1;
		}
		var tempArray = new Object[length];

		for (int i = 0; i <= top; i++)
		{
			tempArray[i] = array[i];
		}
		array = tempArray;
	}
}
