using System.Text;

var linkedLists=new ChapterIILinkedLists();

/*2.1*/

var array=new int[]{1,2,3,4,5,8,5,10,15,20,1,20,50,20};
var node=ListFactory.CreateLinkedList(array);
ListFactory.PrintList(node,"Before cleaning:");
linkedLists.RemoveDuplicates(node);
ListFactory.PrintList(node,"After cleaning:");


public class ChapterIILinkedLists{

    public void RemoveDuplicates(Node root){
        var current=root;
        var previous=root;
        var explorer=root.Next;
        while(current!=null){
            previous=current;
            explorer=current.Next;
            while(explorer!=null){
                if(current.Value==explorer.Value){
                    RemoveNode(explorer,previous);
                }
                previous=explorer;
                explorer=explorer.Next;                
            }
            current=current.Next;           
        }
    }

    public void RemoveNode(Node explorer,Node previous){
        var temp=explorer.Next;
        previous.Next=temp;
        explorer=temp;
    } 
    

}


public class Node{
    public int Value { get; set; }
    public Node Next { get; set; }
}

public static  class ListFactory{
    public static Node CreateLinkedList(int [] array){
        Node node=new Node{Value=array[0]};
        Node temp=node;
        array.Skip(1).ToList().ForEach(value=>{
            var next=new Node{Value=value};
            temp.Next=next;
            temp=next;
        });
        return node;
    }

    public static void PrintList(Node root,string header=""){
        Node current=root;
        StringBuilder builder=new StringBuilder();
        builder.AppendLine(header);
        while(current!=null){
            builder.Append($"{current.Value}->");
            current=current.Next;
        }
        Console.WriteLine(builder.ToString());
    }
}