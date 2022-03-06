public class Node{
    public int Value { get; set; }
    public Node Next { get; set; }

    public Node Min {get;set;}    
}

public class Excercise_2_StackWithMinimum{

    Node head;

    public void Push(int value){
        Node element=new Node{Value=value};
        if(head==null){
            head=element;
            element.Min=element;
        }else{
            element.Min=Math.Min(head.Min.Value,element.Value)==element.Value?element:head.Min;
            element.Next=head;
            head=element;
        }
    }

    public int GetMinimum(){
        if(head==null)throw new EmptyStackException();
        return head.Min.Value;
    }

    public int Pop(){
        if(head==null)throw new EmptyStackException();
        int value=head.Value;
        head=head.Next;
        return value;
    }

}

public class EmptyStackException:Exception{
    
}