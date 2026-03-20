namespace models;
public class Node
{
    public int Value {private set; get;}
    public Node? Left { set; get;}
    public Node? Right { set;  get;}
    public Node? Parent { set;  get;}
    public Node(int val, Node? left, Node? right)
    {
        Value=val;
        Left=left;
        Right=right;
    }
    public Node(int val)
    {
        Value=val;
        Left=null;
        Right=null;
    }
    public Node(int val, Node parent)
    {
        Value=val;
        Left=null;
        Right=null;
        Parent = parent;
    }
}