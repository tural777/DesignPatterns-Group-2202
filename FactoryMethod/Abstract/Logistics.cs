using System;

namespace FactoryMethod
{
    abstract class Logistics
    {
        public void Delivery()
        {
            Console.WriteLine("Logistics Delivery");
        }

        public abstract ITransport CreateTansport();
    }
}
