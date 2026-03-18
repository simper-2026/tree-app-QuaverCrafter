namespace models;

public class BinaryTree
{
   public BinaryTree(Node root){
    Root = root;
   }
   public BinaryTree(){
    Root = null;
   }
   public Node ? Root {get; private set;}
    public void Insert(int value)
    {
        if (Root == null) {
            Root = new Node(value);
            return;
        }
        else Check(Root, value);
        
        
    }
    private void Check(Node node, int value){
        if (node.Value == value) return;
        if (value < node.Value ){
            if (node.Left == null) node.Left = new Node(value);
            else Check(node.Left, value);
        }
        if (value > node.Value ){
            if (node.Right == null) node.Right = new Node(value);
            else Check(node.Right, value);
        }
    }
    string InOrder(){
        return "";
    }
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
        return $"graph TD;\n"+ToMermaid(Root, ref counter)+"\n";
        
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
            temp += current.Value+" --> "+current.Left.Value+" \n";
            temp += ToMermaid(current.Left, ref counter);
        }
         if (current.Right != null)
        {
            temp += current.Value+" --> "+current.Right.Value+" \n";
            temp += ToMermaid(current.Right, ref counter);
        }
        counter ++;
        return temp;
    }
}