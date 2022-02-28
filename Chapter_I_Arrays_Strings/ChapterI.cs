using System.Text;

var chapterI=new Chapter_I_ArraysAndStrings();

/*
1.*/
var unique="arbol";
var noUnique="Pepe";
Console.WriteLine($"{unique} is unique={chapterI.HasUniqueCharacters(unique)}");
Console.WriteLine($"{noUnique} is unique={chapterI.HasUniqueCharacters(noUnique)}");

/*2.*/

var a="aba";
var b="baa";
Console.WriteLine($"{b} is permutation of {a} ={chapterI.isPermutation(a,b)}");
Console.WriteLine($"{b} is permutation of {a} ={chapterI.IsPermutationSort(a,b)}");

a="caba";
Console.WriteLine($"{b} is permutation of {a} ={chapterI.IsPermutationSort(a,b)}");


/*3.*/

var mrJohnSmith="Mr John Smith    "; int mrSmithLenght=13;
Console.WriteLine($"The string {mrJohnSmith} with lenght={mrSmithLenght} as URL={chapterI.URLify(mrJohnSmith,mrSmithLenght)} ");

/*4.*/
var tacoCat="Tact Coa";
var anita="anita lava la tina";
Console.WriteLine($"Is {tacoCat} a permutation of a palindrome?={chapterI.isAPalindromePermutation(tacoCat)}");
Console.WriteLine($"Is {anita} a permutation of a palindrome?={chapterI.isAPalindromePermutation(anita)}");
var lava="lava avaal";

Console.WriteLine($"Is {lava} a permutation of a palindrome?={chapterI.isAPalindromePermutation(lava)}");

/*5.*/
string pale="pale",ple="ple", pales="pales", bale="bale",bake="bake", pape="pape";
Console.WriteLine($"{pale} is one edit away from {ple}?= {chapterI.IsOneAway(pale,ple)}");

Console.WriteLine($"{pales} is one edit away from {pale}?= {chapterI.IsOneAway(pales,pale)}");

Console.WriteLine($"{pale} is one edit away from {bale}?= {chapterI.IsOneAway(pale,bale)}");

Console.WriteLine($"{pale} is one edit away from {bake}?= {chapterI.IsOneAway(pale,bake)}");

Console.WriteLine($"{pale} is one edit away from {pape}?= {chapterI.IsOneAway(pale,pape)}");

Console.WriteLine($"{pale} is one edit away from {pale}?= {chapterI.IsOneAway(pale,pale)}");

//Second way
Console.WriteLine($"{pale} is one edit away from {ple}?= {chapterI.isOneWaySimple(pale,ple)}");

Console.WriteLine($"{pales} is one edit away from {pale}?= {chapterI.isOneWaySimple(pales,pale)}");

Console.WriteLine($"{pale} is one edit away from {bale}?= {chapterI.isOneWaySimple(pale,bale)}");

Console.WriteLine($"{pale} is one edit away from {bake}?= {chapterI.isOneWaySimple(pale,bake)}");

Console.WriteLine($"{pale} is one edit away from {pape}?= {chapterI.isOneWaySimple(pale,pape)}");

Console.WriteLine($"{pale} is one edit away from {pale}?= {chapterI.isOneWaySimple(pale,pale)}");

var take="take"; var takis="takis";
Console.WriteLine($"{take} is one edit away from {takis}?= {chapterI.isOneWaySimple(take,takis)}");

/*6*/

var test="aabcccccaaa";
Console.WriteLine($"{test} has been compressed to {chapterI.StringCompression(test)}");

test="ab";

Console.WriteLine($"{test} has been compressed to {chapterI.StringCompression(test)}");


/*7-*/
int [,] matrix=new int[4,4];
matrix[0,0]=1;
matrix[0,1]=2;
matrix[0,2]=3;
matrix[0,3]=4;
matrix[1,0]=5;
matrix[1,1]=6;
matrix[1,2]=7;
matrix[1,3]=8;
matrix[2,0]=9;
matrix[2,1]=10;
matrix[2,2]=11;
matrix[2,3]=12;
matrix[3,0]=13;
matrix[3,1]=14;
matrix[3,2]=15;
matrix[3,3]=16;



Console.WriteLine("Original:");
chapterI.printMatrix(matrix);

Console.WriteLine("New:");
chapterI.printMatrix(chapterI.Rotate90(matrix));

/*1.8 0*/
matrix=new int[3,6];
matrix[0,0]=1;
matrix[0,1]=2;
matrix[0,2]=3;
matrix[0,3]=4;
matrix[0,4]=5;
matrix[0,5]=6;
matrix[1,0]=7;
matrix[1,1]=8;
matrix[1,2]=9;
matrix[1,3]=0;
matrix[1,4]=11;
matrix[1,5]=12;
matrix[2,0]=13;
matrix[2,1]=14;
matrix[2,2]=15;
matrix[2,3]=16;
matrix[2,4]=17;
matrix[2,5]=18;

Console.WriteLine("Original:");
chapterI.printMatrix(matrix);

Console.WriteLine("New:");
chapterI.ZeroMatrix(matrix);
chapterI.printMatrix(matrix);

/*1.9*/

var waterbottle="waterbottle";
var erbottlewat="erbottlewat";

Console.WriteLine($"{waterbottle} is a rotation of {erbottlewat}?={chapterI.IsStringRotation(waterbottle,erbottlewat)}");


public class Chapter_I_ArraysAndStrings{


    public Action<int[,]> printMatrix=(int [,]arr)=>{
        StringBuilder builder=new StringBuilder();
        for(int i=0;i<arr.GetLength(0);i++){
            for(int j=0;j<arr.GetLength(1);j++){
                builder.Append($"{arr[i,j]} ");
            }
            builder.AppendLine();
        }
        Console.Write(builder.ToString());
    };

    public bool HasUniqueCharacters(string input){
        for(int i=0;i<input.Length-1;i++){
            for(int j=i+1;j<input.Length;j++){
                if(input[i]==input[j]){
                    return false;
                }
            }
        }
        return true;
    }


    public bool IsPermutationSort(string a, string b){
        var sortedA=new String(a.OrderBy(letter=>letter).ToArray());
        var sortedB=new String(b.OrderBy(letter=>letter).ToArray());
        return sortedA==sortedB;
    }


    public bool isPermutation(string a, string b){
        var dictionary=GetLetterDictionary(a);
        foreach(var letter in b){
            if(dictionary.ContainsKey(letter)==false) return false;
            dictionary[letter]-=1;
        }
        return IsEmpty(dictionary);
    }


    public Dictionary<char,int> GetLetterDictionary(string a){
        var dictionary=new Dictionary<char,int>();
        foreach(var letter in a){
            if (dictionary.ContainsKey(letter))continue;
            dictionary[letter]=a.Count(currentChar=> currentChar==letter);
        }
        return dictionary;
    }

    public bool IsEmpty(Dictionary<char,int> dictionary){
        int count=0;
        foreach(var keyvalue in dictionary){
            count+=keyvalue.Value;
        }
        return count==0;
    }



    public string URLify(string url, int lenght){
        var urlify=url.ToArray();
        if(urlify.Length<lenght)return "";
        int spaceCount=urlify.Count(x=>x==' ')-(urlify.Length-lenght);
        if(spaceCount==0)return url;
        int pointer=urlify.Length-1;
        for(int i=lenght-1;i>=0&&spaceCount>0;i--){
            if(urlify[i]!=' '){
                urlify[pointer--]=url[i];
            }else{
                urlify[pointer--]='0';
                urlify[pointer--]='2';
                urlify[pointer--]='%';
                spaceCount--;
            }
        }
        return new String(urlify);
    }


    public bool isAPalindromePermutation(string permutation){
        Dictionary<char,int> letters=new Dictionary<char, int>();
        foreach(var letter in permutation.ToLower()){
            if(letter==' ')continue;
            if(letters.ContainsKey(letter)){
                letters[letter]++;
            }else{
                letters.Add(letter,1);
            }
        }
        var min=letters.MinBy(kvp=>kvp.Value);
        var allPairs=letters.Where(kvp=>kvp.Key!=min.Key).Count(b=>b.Value%2!=0)==0;
        return min.Value%2==0&&allPairs||allPairs;       
        
    }

    public bool IsOneAway(string a, string b){
        int [,] matrix=new int[a.Length,b.Length];
       
        for(int i=0; i<matrix.GetLength(0);i++){
            for(int j=0;j<matrix.GetLength(1);j++){               
                int carryOn=0;
                if(i>0&&j==0){
                    carryOn=matrix[i-1,j];
                }
                else if(i>0&&j>0){
                    carryOn=Math.Max(matrix[i-1,j],matrix[i,j-1]);
                }else if(i==0&&j>0){
                    carryOn=matrix[i,j-1];
                }               
                if(a[i]==b[j]){
                    carryOn++;
                }
                matrix[i,j]=carryOn;                
            }
        }
        var diff=Math.Abs(a.Length-matrix[a.Length-1,b.Length-1]);
        return diff==1||diff==0;
    }

    public bool isOneWaySimple(string a, string b){

        string smaller=(a.Length>b.Length)?b:a;
        string bigger=(a.Length>b.Length)?a:b;

        int pointerSmall,pointerBig,differences;
        pointerSmall=pointerBig=differences=0;

        if (Math.Abs(bigger.Length-smaller.Length)>1) return false;
        


        while(pointerSmall<smaller.Length&&pointerBig<bigger.Length&&differences<=1){
            if(smaller[pointerSmall]==bigger[pointerBig]){
                pointerSmall++;
                pointerBig++;
            }else{
                pointerBig++;
                differences++;
            }
            
        }
        return differences==0||differences==1;       

    }


    public string StringCompression(string input){
        char currentChar=default(char);
        int count=0;
        StringBuilder builder=new StringBuilder();
        foreach(var letter in input){
            if(currentChar==default(char)){
                currentChar=letter;
                count++;
            }else if(currentChar==letter){
                count++;
            }else{
                builder.Append($"{currentChar}{count}");
                count=1;
                currentChar=letter;
            }
        }
        builder.Append($"{currentChar}{count}");
        var compressedString=builder.ToString();
        return (compressedString.Length<input.Length)?compressedString:input;
        
    }


    public int [,] Rotate90(int [,] array){
        var h=array.GetLength(0);
        var l=array.GetLength(1);
        if(h%4!=0&&l%4!=0) return null;
        h--;l--;
        int a,b,c,d;
        
        for(int i=0;i<l;i++){
           a=array[0,i];
           b=array[i,l];
           c=array[h,l-i];
           d=array[h-i,0];

           //a->b
           array[i,l]=a;
           //b->c
           array[h,l-i]=b;
           //c->d
           array[h-i,0]=c;
           //d->a
           array[0,i]=d;

                                                            
        }
        return array;
        
    }


    public void ZeroMatrix(int [,]a){
        Queue<Tuple<int,int>> coordinates=new Queue<Tuple<int,int>>();
        
        for(int i=0;i<a.GetLength(0);i++){
            for(int j=0;j<a.GetLength(1);j++){
                if(a[i,j]==0){
                    coordinates.Enqueue(new Tuple<int, int>(i,j));
                }
            }
        }
        while(coordinates.Count>0){
            var coordinate=coordinates.Dequeue();
            DoZeros(a,coordinate.Item1,coordinate.Item2);
        }
        

    }

    public void DoZeros(int [,]a,int i, int j){
        for(int z=0;z<a.GetLength(0);z++){
            a[z,j]=0;
        }
        for(int y=0;y<a.GetLength(1);y++){
            a[i,y]=0;
        }    
    }

    public bool IsStringRotation(string a, string b){
        var fusion=b+b;
        return fusion.Contains(a);
    }

    
}

