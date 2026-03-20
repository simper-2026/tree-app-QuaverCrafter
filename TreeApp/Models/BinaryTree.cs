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
            if (node.Left == null) {
                node.Left = new Node(value, node);
                RotateCheck(node);
                }
            else Check(node.Left);
        }
        if (value > node.Value ){
            if (node.Right == null) {
                node.Right = new Node(value, node);
                RotateCheck(node);
            }
            else Check(node.Right);
        }
    }
    private void RotateCheck(Node node ){
        int diff = HeightFinder(node.Left) - HeightFinder(node.Right);
        if (diff>1) node = RotateRight(node);
        if (diff<-1) node = RotateLeft(node);
        
        if (node.Parent != null) RotateCheck(node.Parent);
        

    }
      Node RotateRight(Node z)
{
    Node parent = z.Parent;
    Node y  = z.Left;
    Node t3 = y.Right;   // T3 moves from y's right to z's left
    y.Right = z;
    z.Left  = t3;
    z.Parent= y;
    if (t3!= null) t3.Parent=z;
    y.Parent = parent;
    if (y.Parent = null) Root = y;
    else if (y.Parent.Left = z) y.Parent.Left =y;
    else y.Parent.Right = y;
    return y;                // y is the new root of this subtree
}
Node RotateLeft(Node z)
{
    Node parent = z.Parent;
    Node y  = z.Right;
    Node t2 = y.Left;
    y.Left  = z;
    z.Right = t2;
    if (t2!= null) t2.Parent=z;
    y.Parent = parent;
    if (y.Parent = null) Root = y;
    else if (y.Parent.Right = z) y.Parent.Right =y;
    else y.Parent.Left = y;
    return y;
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
        if (Root== null)
        {
            return "graph TD; \n";
        }
        if (Root.Right == null && Root.Left == null)
        {
            return $"graph TD;\n{Root.Value}\n";
        }
        int counter = 0;
      
        return $"graph TD;\n"+ToMermaid(Root, ref counter )+"\n";
        
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
            temp += $"{current.Value} --> {current.Left.Value}[ {current.Left.Value} h:{HeightFinder(current.Left)} ] \n";
            counter ++;
            temp += ToMermaid(current.Left, ref counter);
        }
        else {
            temp += $"{current.Value} -->  _ph{current.Value}[ ] \n linkStyle {counter} stroke:none,stroke-width:0,fill:none \n style _ph{current.Value} fill:none,stroke:none,color:none \n"; 
            counter ++;
               
        }
        if (current.Right != null)
        {
        
            temp += $"{current.Value} --> {current.Right.Value}[ {current.Right.Value} h:{HeightFinder(current.Right)} ] \n";
            counter ++;
            temp += ToMermaid(current.Right, ref counter);
        }
        else {
            temp += current.Value+" -->  _ph"+current.Value+"[ ] \n linkStyle "+counter+" stroke:none,stroke-width:0,fill:none \n style _ph"+current.Value+" fill:none,stroke:none,color:none \n";  
            counter ++;
            
        }
        
        return temp;
    }
  
}