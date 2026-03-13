namespace models;

public class BinaryTree
{
   public Node Root {get;}
    void Insert(int value)
    {
        
    }
    string InOrder(){}
    public int Height()
    {
        return HeightFinder(Root);
    }
    private int HeightFinder(Node? current)
    {
        if (current == null)
        {
            return -1;
        }
        int left = HeightFinder(current.Left);
        int right = HeightFinder(current.Right);
        if (left>right) return left +1;
        else return right +1;
    }
    public string ToMermaid()
    {
        int counter = 0;
        if (Root== null)
        {
            return "graph TD; \n";
        }
        if (Root.Right == null && Root.Left == null)
        {
            return $"graph TD;\n"+Root.Value+"\n";
        }
        return $"graph TD;\n"+ToMermaid(Root, counter)+"\n";
        
    }
    private string ToMermaid(Node? current, ref int counter)
    {
        if (current == null||(current.Left == null && current.Right ==null))
        {
            return string.Empty;
        }
        string temp = string.Empty;
        if (current.Left != null)
        {
            temp += node.Value+" --> "+node.Left.Value+" \n";
            temp += ToMermaid(current.Left)
        }
    }
}