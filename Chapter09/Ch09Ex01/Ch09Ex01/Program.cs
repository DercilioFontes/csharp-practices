using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch09Ex01
{
    public abstract class MyBase { }
    internal class MyClass : MyBase { }
    public interface IMyBaseInterface { }
    internal interface IMyBaseInterface2 { }
    internal interface IMyInterface : IMyBaseInterface, IMyBaseInterface2 { }
    internal sealed class MyComplexClass : MyClass, IMyInterface
    {
        public MyComplexClass ShallowCopy()
        {
            return (MyComplexClass)MemberwiseClone();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyComplexClass myObj = new MyComplexClass();
            WriteLine(myObj.ToString());
            WriteLine(myObj.GetHashCode());
            WriteLine(myObj.GetType());
            WriteLine(myObj.Equals(new object()));
            WriteLine(object.Equals(myObj, new object()));
            WriteLine(object.ReferenceEquals(myObj, myObj));
            MyComplexClass myObj2 = myObj.ShallowCopy();
            WriteLine(myObj2.ToString());
            WriteLine(myObj2.GetHashCode());
            WriteLine(object.ReferenceEquals(myObj, myObj2));
            WriteLine(myObj.Equals(myObj2));
            ReadKey();
        }
    }
}
