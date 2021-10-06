using System;

namespace FactoryMethod
{
    class Airplane : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Deliver by air in a container");
        }
    }
}
