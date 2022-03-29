using System.Text;

public class ListOfDepths_3 : IExcercise
{


    public Dictionary<int, TreeNodeWithListNode> GetListOfDepth(TreeNodeWithListNode root){
        Dictionary<int,TreeNodeWithListNode> dictionary=new Dictionary<int, TreeNodeWithListNode>();
        DoListofDepth(dictionary,root,0);
        return dictionary;
    }


    public void DoListofDepth(Dictionary<int,TreeNodeWithListNode> dictionary, TreeNodeWithListNode node, int level){
        if(node==null)return;
        if(dictionary.ContainsKey(level)){
            node.Next=dictionary[level];
            dictionary[level]=node;
        }else{
            dictionary.Add(level,node);
        }
        DoListofDepth(dictionary,node.Left,level+1);
        DoListofDepth(dictionary,node.Right,level+1);
    }


    

    public void RunExcercise()
    {
       var root= new TreeNodeWithListNode(5);
       var three=new TreeNodeWithListNode(3);
       var seven=new TreeNodeWithListNode(7);
       var one=new TreeNodeWithListNode(1);
       var two=new TreeNodeWithListNode(2);
       var six=new TreeNodeWithListNode(6);
       var eight=new TreeNodeWithListNode(8);

       root.Left=three;
       root.Right=seven;

       three.Left=one;
       three.Right=two;

       seven.Left=six;
       seven.Right=eight;      

        var levels=GetListOfDepth(root);
        
        foreach(var level in levels){
            Console.WriteLine($"Printing elements in level {level}:");
            var builder=new StringBuilder();
            var pointer=level.Value;
            while(pointer!=null){
                builder.Append($"{pointer.Value}->");
                pointer=pointer.Next;
            }
            Console.WriteLine(builder.ToString());
        }


        
    }
}


public class TreeNodeWithListNode{

    public TreeNodeWithListNode(int value){
        Value=value;
    }

    public int Value { get; set; }

    public TreeNodeWithListNode Next{get;set;}

    public TreeNodeWithListNode Left{get;set;}

    public TreeNodeWithListNode Right{get;set;}

}