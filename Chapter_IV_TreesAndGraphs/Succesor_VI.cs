public class Succesor_VI : IExcercise
{


    public TreeNode FindSuccesor(TreeNode node){
        if(node.Right!=null){
            return FindMinimum(node.Right);
        }
        var pointer=node.Parent;
        while(pointer!=null&&pointer.Parent!=null&&pointer.Value<node.Value){
            pointer=pointer.Parent;
        }
        return pointer;
    }

    public TreeNode FindMinimum(TreeNode node){
        while(node.Left!=null){
            node=node.Left;
        }
        return node;
    }
    public void RunExcercise()
    {
        TreeNode root=new TreeNode(20);
        
        var n13=new TreeNode(13);
        var n8=new TreeNode(8);
        var n14=new TreeNode(14);

        var n6=new TreeNode(6);
        var n12=new TreeNode(12);
        var n15=new TreeNode(15);

        var n4=new TreeNode(4);
        var n10=new TreeNode(10);

        var n3=new TreeNode(3);
        var n5=new TreeNode(5);
        var n9=new TreeNode(9);
       
        
        root.Left=n13;
        n13.Parent=root;
        n13.Left=n8;        
        n8.Parent=n13;
        n13.Right=n14;
        n14.Parent=n13;

        n14.Right=n15;
        n15.Parent=n14;

        n8.Left=n6;
        n8.Right=n12;
        n6.Parent=n12.Parent=n8;

        n6.Left=n4;
        n4.Parent=n6;

        n4.Left=n3;
        n3.Parent=n4;
        n4.Right=n5;
        n5.Parent=n4;

        n12.Left=n10;
        n10.Parent=n12;
        n10.Left=n9;
        n9.Parent=n10;

        var node=FindSuccesor(n5);

        Console.WriteLine($"Finding the succesor of {n5}");
        Console.WriteLine($"The succesor of {n5} is {node.Value}");


        

    


        

    }
}