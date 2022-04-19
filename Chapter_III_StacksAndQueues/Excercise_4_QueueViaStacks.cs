public class QueueViaStacks : IExcercise
{
    public async void Run()
    {
        MyQueue queue=new MyQueue();    
        for(int i=0; i<100;i++){
            Console.WriteLine($"Enqueueing {i}");
            queue.Enqueue(i);
            if(i%2==0){
                Console.WriteLine($"Dequeued {queue.Dequeue()}"); 
            }
        }

        for(int i=0;i<100;i++){
            Console.WriteLine($"Dequeued {queue.Dequeue()}");
        }

        
    }


}

public class MyQueue{
    private Stack<int> _input;
    private Stack<int> _output;


    public MyQueue(){
        _input=new Stack<int>();
        _output=new Stack<int>();
    }


    public void Enqueue(int value){
        _input.Push(value);        
    }

    public int Dequeue(){     
        if(_output.Count==0){
            Rotate();
        }
        if(_output.Count>0)
            return _output.Pop();
        else
            return default;
        
    }


    public void Rotate(){
        while(_input.Count>0){
            _output.Push(_input.Pop());
        }
    }
}