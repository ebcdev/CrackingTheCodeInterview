using System.Text;

var linkedLists = new ChapterIILinkedLists();

/*2.1*/

var array = new int[] { 1, 2, 3, 4, 5, 8, 5, 10, 15, 20, 1, 20, 50, 20 };
var node = ListFactory<int>.CreateLinkedList(array);
ListFactory<int>.PrintList(node, "Before cleaning:");
linkedLists.RemoveDuplicates(node);
ListFactory<int>.PrintList(node, "After cleaning:");


/*2.2*/
var the5thElement = linkedLists.ReturnKthtoLastNode(5, node);
the5thElement.ForEach(a => Console.WriteLine($"{a}->"));

/*2.3.*/

var stringArray = new string[] { "a", "b", "c", "d", "e", "f" };
var stringLinkedList = ListFactory<string>.CreateLinkedList(stringArray);
var c = stringLinkedList.Next.Next;
ListFactory<string>.PrintList(stringLinkedList, "Before deleting c");
linkedLists.DeleteMiddleNode(c);
ListFactory<string>.PrintList(stringLinkedList, "After deleting c");

/*2.4*/
var partitionArray = new int[] { 3, 5, 8, 5, 10, 2, 1 };
var partitionLinkedList = ListFactory<int>.CreateLinkedList(partitionArray);
ListFactory<int>.PrintList(partitionLinkedList, "Before partitioning");
linkedLists.Partition(partitionLinkedList, 5);
ListFactory<int>.PrintList(partitionLinkedList, "After partitioning");

/*2.5*/
var aArray = new int[] { 7, 1, 6 };
var bArray = new int[] { 5, 9, 2 };

Node<int> a = ListFactory<int>.CreateLinkedList(aArray);
Node<int> b = ListFactory<int>.CreateLinkedList(bArray);

ListFactory<int>.PrintList(a, "Adding a:");
ListFactory<int>.PrintList(b, "to b:");

Node<int> result = linkedLists.Sum(a, b);

ListFactory<int>.PrintList(result, "Result of a+b");


aArray = new int[] { 6, 1, 7 };
bArray = new int[] { 9, 5 };

a = ListFactory<int>.CreateLinkedList(aArray);
b = ListFactory<int>.CreateLinkedList(bArray);

ListFactory<int>.PrintList(a, "Adding a in order:");
ListFactory<int>.PrintList(b, "to b:");

result = linkedLists.SumInOrder(a, b);

ListFactory<int>.PrintList(result, "Result of a+b in order");

/*2.6*/
var tacoCat = "anitalavalatina".ToCharArray();
var tacoCatList = ListFactory<char>.CreateLinkedList(tacoCat);
ListFactory<char>.PrintList(tacoCatList, $"Is {tacoCatList} a palindrome?");
bool isPalindrome = linkedLists.IsPalindromeAlternative(tacoCatList);
Console.WriteLine($"R={isPalindrome}");

/*2.7*/
var intersectArrayA=new int[] {1,2,3,4,5,6};
var intersectArrayB=new int[]{7,8,9,10};
Node<int> intersectA=ListFactory<int>.CreateLinkedList(intersectArrayA);
Node<int> intersectB=ListFactory<int>.CreateLinkedList(intersectArrayB);
var lastB=intersectB.LastElement();
var intersectionWithA=intersectA.FirstElement(node=>node.Value==5);
lastB.Next=intersectionWithA;

ListFactory<int>.PrintList(intersectA,"ListA:");
ListFactory<int>.PrintList(intersectB,"ListB:");

Node<int> intersection=linkedLists.IntersectionNice(intersectA,intersectB);
var output=intersection==null?"No intersection":""+intersection.Value;
Console.WriteLine($"A and B intersect at {output}");

/*2.8*/
var loopedArray="abcdefgh".ToCharArray();
var loopedList=ListFactory<char>.CreateLinkedList(loopedArray);
var end=loopedList.LastElement();
var loop=loopedList.FirstElement(element=>element.Value=='b');
end.Next=loop;

var loopStart=linkedLists.FindLoopNode(loopedList);
Console.WriteLine($"The start of the loop is {loopStart.Value}");

loopStart=linkedLists.FindLoopNodeWithHashes(loopedList);
Console.WriteLine($"The start of the loop is {loopStart.Value}");


public class ChapterIILinkedLists
{

    public void RemoveDuplicates(Node<int> root)
    {
        var current = root;
        var previous = root;
        var explorer = root.Next;
        while (current != null)
        {
            previous = current;
            explorer = current.Next;
            while (explorer != null)
            {
                if (current.Value == explorer.Value)
                {
                    RemoveNode(explorer, previous);
                }
                previous = explorer;
                explorer = explorer.Next;
            }
            current = current.Next;
        }
    }

    public void RemoveNode(Node<int> explorer, Node<int> previous)
    {
        var temp = explorer.Next;
        previous.Next = temp;
        explorer = temp;
    }


    public List<int> ReturnKthtoLastNode(int k, Node<int> root)
    {
        List<int> values = new List<int>();
        int counter = 0;
        Node<int> backPointer = root;
        Node<int> frontPointer = root;
        
        
        while (frontPointer != null)
        {
            frontPointer = frontPointer.Next;
            counter++;
            if (counter > k)
            {
                backPointer = backPointer.Next;
                counter--;
            }
        }
        if (counter == k)
        {
            while (backPointer != null)
            {
                values.Add(backPointer.Value);
                backPointer = backPointer.Next;
            }
        }
        return values;

    }


    public void DeleteMiddleNode(Node<string> node)
    {
        if (node.Next != null)
        {
            var next = node.Next;
            node.Value = next.Value;
            node.Next = next.Next;
        }
        else
        {
            node = null;
        }
    }


    public void Partition(Node<int> root, int partition)
    {
        Node<int> partitionNode = null;
        Node<int> partitionNodePointer = null;
        Node<int> pointer = root;
        Node<int> less = null;
        Node<int> lessPointer = null;
        Node<int> bigger = null;
        Node<int> biggerPointer = null;
        while (pointer != null)
        {
            if (pointer.Value == partition)
            {
                Append(ref partitionNode, ref partitionNodePointer, ref pointer);
            }
            else
            {
                if (pointer.Value >= partition)
                {
                    Append(ref bigger, ref biggerPointer, ref pointer);
                }
                else
                {
                    Append(ref less, ref lessPointer, ref pointer);
                }
            }
            pointer = pointer.Next;
        }
        root = less;
        lessPointer.Next = partitionNode;
        partitionNodePointer.Next = bigger;
        biggerPointer.Next = null;
    }


    public void Append(ref Node<int> header, ref Node<int> pointer, ref Node<int> insertion)
    {
        if (header == null)
        {
            header = insertion;
            pointer = header;
        }
        else
        {
            pointer.Next = insertion;
            pointer = insertion;
        }
    }


    public Node<int> Sum(Node<int> a, Node<int> b)
    {
        Node<int> result = default;
        Node<int> resultPointer = result;
        Node<int> pointerA = a;
        Node<int> pointerB = b;
        int carry, tempA, tempB;
        carry = tempA = tempB = 0;
        while (pointerA != null || pointerB != null || carry != 0)
        {
            tempA = pointerA != null ? pointerA.Value : 0;
            tempB = pointerB != null ? pointerB.Value : 0;

            tempA += tempB + carry;

            carry = tempA / 10;
            tempA = tempA % 10;
            if (result == null)
            {
                result = new Node<int> { Value = tempA };
                resultPointer = result;
            }
            else
            {
                resultPointer.Next = new Node<int> { Value = tempA };
                resultPointer = resultPointer.Next;
            }
            pointerA = pointerA.Next;
            pointerB = pointerB.Next;
        }
        return result;

    }

    public Node<int> SumInOrder(Node<int> a, Node<int> b)
    {
        Node<int> result = default;
        Node<int> tempResult;
        Node<int> pointerA = a;
        Node<int> pointerB = b;
        int carry, tempA, tempB;
        carry = tempA = tempB = 0;
        Stack<int> temp = new Stack<int>();

        int lenghtA = pointerA.GetLength();
        int lenghtB = pointerB.GetLength();
        int difference = Math.Abs(lenghtA - lenghtB);

        if (difference > 0)
        {
            if (lenghtA > lenghtB)
            {
                pointerB = pointerB.Pad(difference, 0);
            }
            else
            {
                pointerA = pointerA.Pad(difference, 0);
            }
        }

        while (pointerA != null || pointerB != null)
        {
            tempA = (pointerA == null) ? 0 : pointerA.Value;
            tempB = (pointerB == null) ? 0 : pointerB.Value;
            tempA += tempB;
            temp.Push(tempA);
            pointerA = pointerA.Next;
            pointerB = pointerB.Next;
        }
        while (temp.Count > 0 || carry != 0)
        {
            tempA = (temp.Count > 0) ? temp.Pop() : 0;
            tempA += carry;
            carry = tempA / 10;
            tempA = tempA % 10;
            tempResult = new Node<int> { Value = tempA, Next = result };
            result = tempResult;
        }
        return result;
    }

    public bool IsPalindrome(Node<char> root)
    {
        Node<char> pointer = root;
        StringBuilder builder = new StringBuilder();
        Stack<char> stack = new Stack<char>();
        while (pointer != null)
        {
            builder.Append(pointer.Value);
            stack.Push(pointer.Value);
            pointer = pointer.Next;
        }
        StringBuilder builder2 = new StringBuilder();
        while (stack.Count > 0)
        {
            builder2.Append(stack.Pop());
        }
        return builder.ToString() == builder2.ToString();
    }


    public bool IsPalindromeAlternative(Node<char> root)
    {
        Node<char>? pointer = root;
        Node<char>? pointerFast = root;
        Stack<char> stack = new Stack<char>();
        var result=false;
        while (pointerFast != null&&pointerFast.Next!=null)
        {
            stack.Push(pointer.Value);
            pointer=pointer.Next;
            pointerFast=pointerFast.Next.Next;
        }
        if(pointerFast!=null){
            pointer=pointer.Next;
        }
        while(pointer!=null&&stack.Count>0){
            if(pointer.Value==stack.Pop()){
                result=true;
                pointer=pointer.Next;
            }else{
                return false;
            }
        }
        return result;
    
    }

    public Node<int> Intersection(Node<int> a, Node<int> b){
        Dictionary<Node<int>,int> hashTable=new Dictionary<Node<int>, int>();
        var pointerA=a;
        var pointerB=b;

        while(pointerA!=null||pointerB!=null){
            if(pointerA!=null){
                if(hashTable.ContainsKey(pointerA)){
                    return pointerA;
                }else{
                    hashTable.Add(pointerA,pointerA.Value);
                    pointerA=pointerA.Next;
                }
            }
            if(pointerB!=null){
                if(hashTable.ContainsKey(pointerB)){
                    return pointerB;
                }else{
                    hashTable.Add(pointerB,pointerB.Value);
                    pointerB=pointerB.Next;
                }
            }
        }
        return null;
    }


    public Node<int> IntersectionNice(Node<int>a, Node<int>b){
        
        Node<int> pointerA=a;
        Node<int> pointerB=b;
        var lastElementAndSizeA=GetLastElementAndSize(pointerA);
        var lastElementAndSizeB=GetLastElementAndSize(pointerB);
        if(lastElementAndSizeA.Item2!=lastElementAndSizeB.Item2)
            return null;
        
        var larger=lastElementAndSizeA.Item1>lastElementAndSizeB.Item1?pointerA:pointerB;
        var smaller=lastElementAndSizeA.Item1<=lastElementAndSizeB.Item1?pointerA:pointerB;

        var difference=Math.Abs(lastElementAndSizeA.Item1-lastElementAndSizeB.Item1);

        while(difference>0){
            larger=larger.Next;
            difference--;
        }

        while(larger!=null&&smaller!=null){
            if(larger==smaller){
                return larger;
            }else{
                larger=larger.Next;
                smaller=smaller.Next;
            }
        }
        return null;
        

        

    }

    public Tuple<int,Node<int>> GetLastElementAndSize(Node<int> node){
        if(node==null)return new Tuple<int, Node<int>>(0,node);
        var pointer=node;
        var size=1;
        while(pointer.Next!=null){
            pointer=pointer.Next;
            size++;
        }
        return new Tuple<int, Node<int>>(size,pointer);
    }


    public Node<char> FindLoopNode(Node<char> root){
        var slow=root;
        var fast=root;
        while(slow!=null&&fast.Next!=null){
            slow=slow.Next;
            fast=fast.Next.Next;
            if(slow==fast)
                break;
        }
        if(fast==null||fast.Next==null)return null;

        slow=root;
        while(slow!=fast){
            slow=slow.Next;
            fast=fast.Next;
        }
        return fast;
    }

    public Node<char> FindLoopNodeWithHashes(Node<char>root){
        var pointer=root;
        Dictionary<Node<char>,Node<char>> values=new Dictionary<Node<char>, Node<char>>();        
        while(pointer!=null){
            if(values.ContainsKey(pointer)){
                return pointer;
            }else{
                values.Add(pointer,pointer);
            }
            pointer=pointer.Next;
        }
        return null;
    }







}


public class Node<T>
{
    public T Value { get; set; }
    public Node<T>? Next { get; set; }

    public int GetLength()
    {
        int counter = 1;
        Node<T> next = Next;
        while (next != null)
        {
            counter++;
            next = next.Next;
        }
        return counter;
    }

    public Node<T> Pad(int number, T value)
    {
        Node<T> node = this;
        while (number > 0)
        {
            var temp = new Node<T> { Value = value, Next = node };
            node = temp;
            number--;
        }
        return node;
    }

    public Node<T> LastElement(){
        Node<T> node=this;
        while(node.Next!=null)
        {
            node=node.Next;
        }
        return node;
    }

    public Node<T> FirstElement(Predicate<Node<T>> comparer){
        Node<T> node=this;
        while(node!=null){
            if(comparer(node)){
                return node;
            }else{
                node=node.Next;
            }
        }
        return null;
    }

}

public static class ListFactory<T>
{
    public static Node<T> CreateLinkedList(T[] array)
    {
        Node<T> node = new Node<T> { Value = array[0] };
        Node<T> temp = node;
        array.Skip(1).ToList().ForEach(value =>
        {
            var next = new Node<T> { Value = value };
            temp.Next = next;
            temp = next;
        });
        return node;
    }

    public static void PrintList(Node<T> root, string header = "")
    {
        Node<T> current = root;
        StringBuilder builder = new StringBuilder();
        builder.AppendLine(header);
        while (current != null)
        {
            builder.Append($"{current.Value}->");
            current = current.Next;
        }
        Console.WriteLine(builder.ToString());
    }
}