namespace ConsoleApp3
{
    class Program
    {
        private static void Main(string[] args)
        {
            Publisher publisher = new Publisher();
            Subscriber subscriber1 = new Subscriber("First Subscriber");
            Subscriber subscriber2 = new Subscriber("Second Subscriber");

            publisher.MyEvent += subscriber1.OnDataReceived;
            publisher.MyEvent += subscriber2.OnDataReceived;
            publisher.RaiseEvent("Event from Publisher!");
        }
    }

    public class Publisher
    {
        public delegate void MyEventHandler(string data);     
        public event MyEventHandler MyEvent;
        public void RaiseEvent(string data)
        {
            Console.WriteLine("Raise Event");
            MyEvent?.Invoke(data);
        }
    }

    public class Subscriber
    {
        private string _name;
        public Subscriber(string name)
        {
            _name = name;
        }

        public void OnDataReceived(string data)
        {
            Console.WriteLine($"Subscriber '{_name}' received data: {data}");
        }
    }
}
