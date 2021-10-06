using System;

namespace FactoryMethod
{
    class Truck : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Deliver by land in a box");
        }
    }
}
