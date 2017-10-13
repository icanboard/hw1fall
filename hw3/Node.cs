/**
/ A simple singly linked node class. This implementation comes from
/ before Java had Generics. 
/ Converted from Java to C# by Jake Hatfield
*/
public class Node
{
	public object Data; // The payload
	public Node Next;   // Reference to the next Node in the chain
	
	public Node()
	{
		Data = null;
		Next = null;
	}
	
	public Node(object data, Node next)
	{
		this.Data = data;
		this.Next = next;
	}
}