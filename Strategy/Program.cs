using System;

namespace Strategy // Strategiya
{
    interface ISerializer
    {
        void Serialize();
    }



    class JsonSerializer : ISerializer
    {
        public void Serialize()
        {
            Console.WriteLine("Json Serialize");
        }
    }

    class XMLSerializer : ISerializer
    {
        public void Serialize()
        {
            Console.WriteLine("XML Serialize");
        }
    }

    class BinarySerializer : ISerializer
    {
        public void Serialize()
        {
            Console.WriteLine("Binary Serialize");
        }
    }



    class SerializeStrategy
    {
        private readonly ISerializer _serializer;

        public SerializeStrategy(ISerializer serializer)
        {
            _serializer = serializer;
        }

        public void Serialize()
        {
            _serializer.Serialize();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            // Dependency Inversion Principle

            SerializeStrategy serializeStrategy = new SerializeStrategy(new BinarySerializer());
            serializeStrategy.Serialize();
        }
    }
}