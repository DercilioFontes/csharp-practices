using Ch22Ex01Client.ServiceReference1;
using static System.Console;

namespace Ch22Ex01Client
{
    class Program
    {
        static void Main()
        {
            Title = "Ch22Ex01Client";

            string numericInput;
            int intParam;
            do
            {
                WriteLine("Enter an integer and press enter to call the WCF service.");
                numericInput = ReadLine();
            } while (!int.TryParse(numericInput, out intParam));

            Service1Client client = new Service1Client();
            CompositeType composite = new CompositeType { BoolValue = true, StringValue = "Casa"};

            WriteLine("GetData: " + client.GetData(intParam));
            WriteLine("GetDataUsingDataContrct: " + client.GetDataUsingDataContract(composite).StringValue);
            WriteLine("Press an key to exit.");
            _ = ReadKey();
        }
    }
}
