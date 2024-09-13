namespace ConsoleApp2
{
    internal class Program
    {
        public delegate void SimpleDelegate(string message);

        static void Main(string[] args)
        {
            SimpleDelegate del = DisplayMessage;

            del += DisplayUpperMessage;

            del -= DisplayMessage;


            foreach (Delegate d in del.GetInvocationList())
            {
                Console.WriteLine(d.Method.Name);
            }


            del("Hello ");

            del.Invoke("world!");


            void DisplayMessage(string message) 
            { 
                Console.WriteLine (message);            
            }

            void DisplayUpperMessage(string message)
            {
                Console.WriteLine(message.ToUpper());
            }
        }
    }
}
