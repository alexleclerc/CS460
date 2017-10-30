using System;

public interface IStackADT
{
    object Push(object newItem);

    object Pop();

    object Peek();

    bool IsEmpty();

    void Clear();
}
