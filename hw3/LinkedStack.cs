using System;


/**
/ A singly linked stack implementation. Converted from Java to C# by Jake Hatfield.
*/ 
public class LinkedStack : IStackADT
{
	private Node Top;
	
	public LinkedStack()
	{
		Top = null; // Empty stack condition
	}
	
	public object Push(object newItem)
	{
		if(newItem == null)
		{
			return null;
		}
		Node NewNode = new Node(newItem,Top);
		Top = NewNode;
		return newItem;
	}
	
	public object Pop()
	{
		if(IsEmpty())
		{
			return null;
		}
        object TopItem = Top.Data;
		Top = Top.Next;
		return TopItem;
	}
	
	public object Peek()
	{
		if(IsEmpty())
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