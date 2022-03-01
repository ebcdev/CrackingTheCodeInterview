﻿using System.Text;

var linkedLists=new ChapterIILinkedLists();

/*2.1*/

var array=new int[]{1,2,3,4,5,8,5,10,15,20,1,20,50,20};
var node=ListFactory<int>.CreateLinkedList(array);
ListFactory<int>.PrintList(node,"Before cleaning:");
linkedLists.RemoveDuplicates(node);
ListFactory<int>.PrintList(node,"After cleaning:");


/*2.2*/
var the5thElement=linkedLists.ReturnKthtoLastNode(5,node);
the5thElement.ForEach(a=>Console.WriteLine($"{a}->"));

/*2.3.*/

var stringArray =new string[]{"a","b","c","d","e","f"};
var stringLinkedList=ListFactory<string>.CreateLinkedList(stringArray);
var c=stringLinkedList.Next.Next;
ListFactory<string>.PrintList(stringLinkedList,"Before deleting c");
linkedLists.DeleteMiddleNode(c);
ListFactory<string>.PrintList(stringLinkedList,"After deleting c");

/*2.4*/
var partitionArray=new int[] {3,5,8,5,10,2,1};
var partitionLinkedList=ListFactory<int>.CreateLinkedList(partitionArray);
ListFactory<int>.PrintList(partitionLinkedList,"Before partitioning");
linkedLists.Partition(partitionLinkedList,5);
ListFactory<int>.PrintList(partitionLinkedList,"After partitioning");



public class ChapterIILinkedLists{

    public void RemoveDuplicates(Node<int> root){
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

    public void RemoveNode(Node<int> explorer,Node<int> previous){
        var temp=explorer.Next;
        previous.Next=temp;
        explorer=temp;
    }


    public List<int> ReturnKthtoLastNode(int k, Node<int> root) {
        List<int> values=new List<int>();
        int counter=0;
        Node<int> backPointer=root;
        Node<int> frontPointer=root;

        while(frontPointer!=null){
            frontPointer=frontPointer.Next;
            counter++;
            if(counter>k){
                backPointer=backPointer.Next;
                counter--;
            }
        }
        if(counter==k){
            while(backPointer!=null){
                values.Add(backPointer.Value);
                backPointer=backPointer.Next;
            }
        }
        return values;

    }


    public void DeleteMiddleNode(Node<string> node){
        if(node.Next!=null){
            var next=node.Next;
            node.Value=next.Value;
            node.Next=next.Next;
        }else{
            node=null;
        }
    }


    public void Partition(Node<int> root, int partition){
        Node<int> partitionNode=null;
        Node<int> partitionNodePointer=null;
        Node<int> pointer=root;
        Node<int> less=null;
        Node<int> lessPointer=null;
        Node<int> bigger=null;
        Node<int> biggerPointer=null;
        while(pointer!=null){
            if(pointer.Value==partition){
                Append(ref partitionNode,ref partitionNodePointer,ref pointer);                
            }else{
                if(pointer.Value>=partition){
                    Append(ref bigger,ref biggerPointer,ref pointer);
                }else{
                    Append(ref less,ref lessPointer,ref pointer);
                }
            }
            pointer=pointer.Next;
        }
        root=less;
        lessPointer.Next=partitionNode;
        partitionNodePointer.Next=bigger;
        biggerPointer.Next=null;
    }


    public void Append(ref Node<int> header,ref Node<int> pointer,ref Node<int> insertion){
        if(header==null){
            header=insertion;
            pointer=header;
        }else{
            pointer.Next=insertion;
            pointer=insertion;
        }
    }
    

}


public class Node<T>{
    public T Value { get; set; }
    public Node<T>? Next { get; set; }

    
}

public static  class ListFactory<T>{
    public static Node<T> CreateLinkedList(T [] array){
        Node<T> node=new Node<T>{Value=array[0]};
        Node<T> temp=node;
        array.Skip(1).ToList().ForEach(value=>{
            var next=new Node<T>{Value=value};
            temp.Next=next;
            temp=next;
        });
        return node;
    }

    public static void PrintList(Node<T> root,string header=""){
        Node<T> current=root;
        StringBuilder builder=new StringBuilder();
        builder.AppendLine(header);
        while(current!=null){
            builder.Append($"{current.Value}->");
            current=current.Next;
        }
        Console.WriteLine(builder.ToString());
    }
}