using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Node
{
    public object Data;
    public Node Next;

	public Node()
	{
        Data = null;
        Next = null;
	}

    public Node(object data, Node next)
    {
        Data = data;
        Next = next;
    }
}
