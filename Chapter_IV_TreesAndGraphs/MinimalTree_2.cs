public class MinimalTree_2 : IExcercise
{

    TreeNode root;

    public TreeNode InitializeTree(int [] orderedArray,int start, int end){

        if(end<start)return null;        
        var mid=(end-start)/2; 
        mid+=start;           
        TreeNode node=new TreeNode(orderedArray[mid]);
        node.Left=InitializeTree(orderedArray,start,mid-1);
        node.Right=InitializeTree(orderedArray,mid+1,end);
        return node;    
       
    }


   
  


    public void PrintTree(TreeNode node,int level=0){
        if(node==null)return;
        PrintTree(node.Left,level+1);
        Console.WriteLine($"{node.Value}".PadLeft(level));
        PrintTree(node.Right,level+1);
    }




    public void RunExcercise()
    {
        int [] array=new int[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20};
        root=InitializeTree(array,0,array.Length-1);
        PrintTree(root);

    }
}

public class TreeNode{

    public TreeNode(int value){
        Value=value;
    }

    public int Value { get; set; }
    

    public TreeNode Left {get;set;}
    public TreeNode Right { get; set; }


    public TreeNode Parent {get;set;}
    
    
}