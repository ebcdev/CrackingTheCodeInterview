public class StackOfPlates : IExcercise
{
    public void Run()
    {
        LimiteStack<int> stack=new LimiteStack<int>(10);
        for(int i=0;i<100;i++){
            Console.WriteLine($"Pushing: {i}");
            stack.Push(i);
        }
        Console.WriteLine($"Valor en stack 3:{stack.Pop(3)}");
        for(int j=0;j<101;j++){
            Console.WriteLine($"Poping:{stack.Pop()}");
        }
        Console.WriteLine($"Valor en stack 3:{stack.Pop(3)}");
    } 
}


public class LimiteStack<T>{
    
    int _capacity=0;
    int _currentLevel=0;
    Dictionary<int,StackNode<T>?> _stackContainer;

    public LimiteStack(int capacity){
        _capacity=capacity;
        _stackContainer=new Dictionary<int, StackNode<T>?>();               

    }

    public void Push(T value){
        if(!_stackContainer.ContainsKey(_currentLevel)){
            _stackContainer.Add(_currentLevel,default);
        }
        var current=_stackContainer[_currentLevel];
        if(current==null){
            current=new StackNode<T>(value);
            current.Lvl=1;
            _stackContainer[_currentLevel]=current;
        }else{
            var temp=new StackNode<T>(value);
            if(current.Lvl<_capacity){               
                temp.Lvl=current.Lvl+1;
                temp.Next=current;
                _stackContainer[_currentLevel]=temp;
            }else{
                temp.Lvl=1;
                _stackContainer.Add(++_currentLevel,temp);
            }
        }
    }

    public T? Pop(){
        if(_currentLevel>=0){
            var value=_stackContainer[_currentLevel];                    
            if(value==null){
                _currentLevel--;               
                return Pop();                
            }else{
                _stackContainer[_currentLevel]=value.Next;
            }
            return value.Value;
        }
        return default;
    }

    public T? Pop(int atIndex){
        if(_stackContainer.ContainsKey(atIndex)){
            var value=_stackContainer[atIndex];
            if(value!=null){
                _stackContainer[atIndex]=value.Next;
                return value.Value;
            }
        }
        return default;
    }




}

public class StackNode<T>{
    T value;
    public StackNode(T value){
        this.value=value;
    }
    public int Lvl { get; set; }    
    public T Value=>value;
    public StackNode<T>? Next{get;set;}


}