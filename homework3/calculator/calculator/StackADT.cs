using System;

public interface IStackADT
{
    /// <summary>
    /// Push an item to the top of the stack. Should throw an error
    /// if the item doesn't exist.
    /// </summary>
    /// <param name="newItem">Object to be pushed onto the stack.</param>
    /// <returns>A reference to the object, or null.</returns>
    object Push(object newItem);

    /// <summary>
    /// Removes and returns the top object off the stack. Should 
    /// throw an error if the stack is empty. 
    /// </summary>
    /// <returns>Reference to the object popped and removed from
    /// the stack.</returns>
    object Pop();

    /// <summary>
    /// Return the top object but don't delete it.
    /// Error if stack is empty, or provide means of 
    /// checking the stack if nothing can be peeked at.
    /// </summary>
    /// <returns>Reference to the top object on the stack, or null 
    /// if the stack was empty.</returns>
    object Peek();

    /// <summary>
    /// Function to check if the stack is empty. Does not throw errors.
    /// </summary>
    /// <returns>If the stack is empty, true, otherwise, false.</returns>
    bool IsEmpty();

    /// <summary>
    /// Empty the stack in some way. Exact method is up to interpretation.
    /// The behaviour should be predictable. 
    /// </summary>
    void Clear();
}
