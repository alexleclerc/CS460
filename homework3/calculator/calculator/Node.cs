using System;

/// <summary>
/// Node class for a singly linked list data structure. 
/// </summary>
public class Node
{
    public object Data; //Payload
    public Node Next; //the next node in the chain

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
