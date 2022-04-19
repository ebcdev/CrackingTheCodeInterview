using System.Collections;

public class Excercise_5_SortAStack : IExcercise
{

   
    
    public void Run()
    {
       SortedStack stack=new SortedStack();
       var numbers=new List<int>{1,2,3,4,6,7,8,9};
       numbers.ForEach(a=>stack.Push(a));
       stack.Push(5);
       while(stack.Count>0){
           Console.WriteLine($"{stack.Pop()}");
       }
       

    }
}

 public class SortedStack{

     private Stack<int> stack;
     private Stack<int> temp;


     public int Count=>stack.Count;

     public SortedStack(){
         stack=new Stack<int>();
         temp=new Stack<int>();
     }
     public void Push(int value){
         while(stack.Count>0&&stack.Peek()<value){                          
             Console.WriteLine($"Popping {stack.Peek()} to temp stack");
             temp.Push(stack.Pop());             
         }
         Console.WriteLine($"Pushing {value} to main stack");
         stack.Push(value);
         while(temp.Count>0){
             Console.WriteLine($"Popping {temp.Peek()} to main stack");
             stack.Push(temp.Pop());
         }         
     }


     public int Peek(){
         return stack.Peek();
     }

     public int Pop(){
         return stack.Pop();
     }

     


}