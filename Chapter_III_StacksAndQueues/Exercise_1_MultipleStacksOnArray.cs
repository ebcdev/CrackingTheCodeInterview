public class Excercise_1_MultipleStacksOnArray
{  
    private const int stack_size=10;
    private int[] array;

    

    private int numberOfStacks;
    Dictionary<int,int> startPointer=new Dictionary<int, int>();
    Dictionary<int,int> currentPointer=new Dictionary<int, int>();   


    public Excercise_1_MultipleStacksOnArray(int numberOfStacks ){      
        this.numberOfStacks=numberOfStacks;  
        array=new int[numberOfStacks*stack_size];
        for(int i=0;i<numberOfStacks;i++){
            var currentStart=i*array.Length/numberOfStacks;
            var pointer=currentStart;
            startPointer.Add(i,currentStart);
            currentPointer.Add(i,currentStart-1);
        }
    }

    public void Push(int stack, int value){
        if(stack>=numberOfStacks||stack<0)
            throw new Exception("Stack doesn't exists");

        var start=startPointer[stack];
        var current=currentPointer[stack];
        if(current-start+1==stack_size){
            throw new Exception("Stack full");
        }
        current+=1;
        array[current]=value;
        currentPointer[stack]=current;
    }

    public int Pop(int stack){
        if(stack>=numberOfStacks||stack<0)
            throw new Exception("Stack doesn't exists");        
        var current=currentPointer[stack];
        var start=startPointer[stack];
        if(current-start==-1){
            throw new Exception("Empty stack");
        }
        var response=array[current];
        currentPointer[stack]-=1;
        return response;
    }

     public int Peek(int stack){
        if(stack>=numberOfStacks||stack<0)
            throw new Exception("Stack doesn't exists");        
        var current=currentPointer[stack];
        var start=startPointer[stack];
        if(current-start==-1){
            throw new Exception("Empty stack");
        }
        var response=array[current];       
        return response;
    }



}