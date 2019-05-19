using System;
using static System.Console;

namespace DeepClone
{
    public class Content
    {
        public int Val;
    }

    public class Cloner : ICloneable
    {
        public Content MyContent = new Content();
        public Cloner(int newVal)
        {
            MyContent.Val = newVal;
        }
        public object Clone()
        {
            Cloner clonedCloner = new Cloner(MyContent.Val);
            return clonedCloner;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Cloner mySource = new Cloner(5);
            Cloner myTarget = (Cloner)mySource.Clone();
            WriteLine($"myTarget.MyContent.Val = {myTarget.MyContent.Val}");
            mySource.MyContent.Val = 2;
            WriteLine($"myTarget.MyContent.Val = {myTarget.MyContent.Val}");
        }
    }
}
