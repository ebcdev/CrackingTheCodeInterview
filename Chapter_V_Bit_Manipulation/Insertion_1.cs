public class Insertion : IExcercise
{
    public int InsertNumber(int n, int m, int start, int end){
       var output=n;
       var mask=0;
       for(int i=end;i<=start;i++){
           mask+=1<<i;
       }
       mask=~mask;
       Console.WriteLine(mask.ToBitString());
       output=(output&mask)|(m<<(end));
       Console.WriteLine(output.ToBitString());
       return output;
    }


    public void RunExcercise()
    {
        int n=0b1101000;
        int m=0b0000;
        var c=InsertNumber(n,m,4,3);
        var str=Convert.ToString(c,2);
    }
}

public static class Extension{
    public static string ToBitString(this int a){
        return Convert.ToString(a,2);
    }
}