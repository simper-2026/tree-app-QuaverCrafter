namespace models;
public class Node
{
    int Value {private set; public get;}
    Node? Left {public set; public get;}
    Node? Right {public set; public get;}
    public Node(int val, Node? left, Node? right)
    {
        Value=val;
        Left=left;
        Right=right;
    }
}