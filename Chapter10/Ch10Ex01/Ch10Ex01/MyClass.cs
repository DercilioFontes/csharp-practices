using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch10Ex01
{
    public class MyClass
    {
        public readonly string Name;
        private string myString;
        private int intVal;
        public int intVal2
        {
            get;
            set;
        }
        private string String2 { get; set; }
        
        // prop
        public int MyProperty { get; set; }

        // propa
        public static int GetMyProperty(DependencyObject obj)
        {
            return (int)obj.GetValue(MyPropertyProperty);
        }

        // propdp
        public int MyProperty
        {
            get { return (int)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // propfull
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }
        
        // propg
        public int MyProperty { get; private set; }

        // getter-only auto-property, and it initialization
        public int MyIntProp2 { get; } = 9;

        public int Val
        {
            get { return intVal; }
            set
            {
                if (value >= 0 && value <= 10)
                    intVal = value;
                else
                    throw (new ArgumentOutOfRangeException("Val", value, "Val must be assigned a value between 0 and 10."));
            }
        }

        public override string ToString() => "Name: " + Name + "\nVal: " + Val;

        private MyClass() : this("Default Name") { }

        public MyClass(string newName)
        {
            Name = newName;
            intVal = 0;
        }

        private int myDoubledInt = 5;
        public int myDoubledIntProp => (myDoubledInt * 2);

        public string MyString
        {
            get
            {
                return myString;
            }

            set
            {
                myString = value;
            }
        }
    }
}
