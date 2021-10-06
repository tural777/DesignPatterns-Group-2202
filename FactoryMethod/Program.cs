namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Logistics logistics = new AirLogistics();
            ITransport transport = logistics.CreateTansport();
            transport.Deliver();
        }
    }
}
