public class ChapterIII{

    public static void Main(string [] args){
        ChapterIII excercises=new ChapterIII();
      /*  excercises.Excercise1();
        excercises.Excercise2();
        excercises.Excercise3();
        excercises.Excercise4();
        excercises.Excercise5();*/
        excercises.Excercise6();
    
    }

    public void Excercise1(){
        Excercise_1_MultipleStacksOnArray excercise=new Excercise_1_MultipleStacksOnArray(3);

        try{
        for(int i=0;i<=3;i++){
            Console.WriteLine($"Pushing a element to stack number {i}");
            excercise.Push(i,1);        
        }
        }catch(Exception err){
            Console.WriteLine(err.ToString());
        }

        try{
            for(int i=1;i<100;i++){
                Console.WriteLine($"Pushing element {i} to stack 2");
                excercise.Push(2,i);
            }
        }catch(Exception err){
            Console.WriteLine(err.ToString());
        }

        try{
            Console.WriteLine($"Poping a element from 0 {excercise.Pop(0)}");
            Console.WriteLine($"Poping a element from 0 {excercise.Pop(0)}");
        }catch(Exception err){
            Console.WriteLine(err.ToString());
        }

        
        Console.WriteLine($"Peeking at first element from 2 {excercise.Peek(2)}");
        

    }


    public void Excercise2(){
        Excercise_2_StackWithMinimum stack=new Excercise_2_StackWithMinimum();

        var values=new int[]{8,5,8,1,2,4,6,0,2};
        values.ToList().ForEach(a=>{
            Console.WriteLine($"Pushing {a} to the stack");
            stack.Push(a);
            Console.WriteLine($"Current Min={stack.GetMinimum()}");
        }
        );
        for(int i=0;i<values.Length-1;i++){
            Console.WriteLine($"Popped {stack.Pop()}");
            Console.WriteLine($"Current Min={stack.GetMinimum()}");
        }        
    }

    public void Excercise3(){
        StackOfPlates plates=new StackOfPlates();
        plates.Run();
    }

    public void Excercise4(){
        QueueViaStacks queue=new QueueViaStacks();
        queue.Run();
    }

    public void Excercise5(){
        Excercise_5_SortAStack stack=new Excercise_5_SortAStack();
        stack.Run();
    }

    public void Excercise6(){
        AnimalShelter shelter=new AnimalShelter();
        shelter.Run();
    }
}