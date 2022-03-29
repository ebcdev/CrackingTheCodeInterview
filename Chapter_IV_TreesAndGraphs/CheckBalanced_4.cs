public class CheckBalanced_4 : IExcercise
{
    
    public int Balanced(TreeNode node){
        if(node==null)return 0;
        int left=Balanced(node.Left);
        int right=Balanced(node.Right);
        if(left==-1||right==-1) return -1;
        if(Math.Abs(left-right)>1){
            return -1;
        }else{
            return Math.Max(left,right)+1;
        }
    }

    public void RunExcercise()
    {
        TreeNode root=new TreeNode(5);
        TreeNode three=new TreeNode(3);
        TreeNode nine=new TreeNode(9);

        TreeNode one=new TreeNode(1);
        TreeNode two=new TreeNode(2);

        TreeNode eight=new TreeNode(8);
        TreeNode ten=new TreeNode(10);

        TreeNode six=new TreeNode(6);
        TreeNode seven=new TreeNode(7);

        root.Left=three;
        root.Right=nine;

        three.Left=one;
        three.Right=two;

        nine.Left=eight;
        nine.Right=ten;
        eight.Left=six;
        //six.Right=seven;

        Console.WriteLine($"Is balanced ={Balanced(root)>-1}");
    }
}