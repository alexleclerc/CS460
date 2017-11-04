/// <summary>
/// Singly linked stack data structure.
/// </summary>
public class LinkedStack : IStackADT
{
    private Node Top;

    public LinkedStack()
    {
        Top = null;
    }

    public object Push(object newItem)
    {
        if (newItem == null)
        {
            return null;
        }
        Node NewNode = new Node(newItem, Top);
        Top = NewNode;
        return newItem;
    }

    public object Pop()
    {
        if (IsEmpty())
        {
            return null;
        }
        object TopItem = Top.Data;
        Top = Top.Next;
        return TopItem;
    }

    public object Peek()
    {
        if (IsEmpty())
        {
            return null;
        }
        return Top.Data;
    }

    public bool IsEmpty()
    {
        return Top == null;
    }

    public void Clear()
    {
        Top = null;
    }
}
