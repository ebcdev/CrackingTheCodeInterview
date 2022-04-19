public class AnimalShelter : IExcercise
{

    public List<Animal> dogs;

    public List<Animal> cats;


    public AnimalShelter(){
        dogs=new List<Animal>();
        cats=new List<Animal>();
    }

    public void Push(Animal animal){
        animal.ArrivalTime=DateTime.Now;
        if(animal is Dog){
            dogs.Add(animal);
        }else{
            cats.Add(animal);
        }
    }

    public Animal? PopEither(){
       var dog=default(Animal);
       var cat=default(Animal);
       if(dogs.Count>0){
           dog=dogs[0];
       }
       if(cats.Count>0){
           cat=cats[0];
       }
       if(dog==cat&&dog==null)return null;

       if(dog==null||dog.ArrivalTime<cat.ArrivalTime){
           cats.Remove(cat);
           return cat;

       }else{
           dogs.Remove(dog);
           return dog;
       }       
      
    }

    public Dog GetADog(){
        if(dogs.Count>0){
            var dog=dogs[0];
            dogs.Remove(dog);
            return dog as Dog;
        }
        return null;
    }

     public Cat GetACat(){
        if(cats.Count>0){
            var cat=cats[0];
            cats.Remove(cat);
            return cat as Cat;
        }
        return null;
    }





    public void Run()
    {
        Dog blackJack=new Dog{Name="Black Jack"};
        Cat silver=new Cat{Name="Silver"};
        Dog duke=new Dog{Name="Duke"};
        Cat silvestre=new Cat{Name="Silvestr"};
        Dog cachito=new Dog{Name="Cachito"};
        Dog candy=new Dog{Name="Candy"};

        Push(silver);
        Push(blackJack);
        Push(duke);
        Push(candy);
        Push(cachito);
        Push(silvestre);

        var animal=PopEither();

        Console.WriteLine($"Popped the oldest animal and is a {animal.GetType().Name} and its name is {animal.Name} ");

        animal=GetACat();
        Console.WriteLine($"Popped a cat and is {animal.Name}  ");

        animal=GetADog();
        Console.WriteLine($"Popped a dog and is {animal.Name}  ");


    }
}

public abstract class Animal{
    public string Name { get; set; }
    public DateTime ArrivalTime { get; set; }

    public abstract void MakeSound();
    
}

public class Cat:Animal{
    public Cat():base(){}

    

    public void Meow(){
        Console.WriteLine("Meow");
    }

    public override void MakeSound(){
        Meow();
    }
}

public class Dog:Animal{
    public Dog():base(){}

    public void Bark(){
        Console.WriteLine("Bark, Bark");
    }

    public override void MakeSound()
    {
        Bark();
    }
}