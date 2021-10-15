using System;

namespace Proxy // Vekil
{

    // 1) Protection Proxy
    // 2) Virtual Proxy (Lazy Initialization )
    // 3) Remote Proxy (CDN)
    // 4) Logging Proxy
    // 5) Caching Proxy - (Omurlerinde de diqqet etmelisiz)




    // EXAMPLE: Protection Proxy
    interface IOperation
    {
        void Request();
    }


    // Real subject (Real Sevice)
    class RealOperationSubject : IOperation
    {
        public void Request()
        {
            Console.WriteLine("Do something");
        }
    }


    // Real subject (Real Sevice)
    class OperationProxy : IOperation
    {
        private IOperation _operationSubject { get; set; }

        public OperationProxy()
        {
            _operationSubject = new RealOperationSubject();
        }

        public void Request()
        {
            if (Program.Role == 1)
                _operationSubject.Request();
            else
                Console.WriteLine("401 - Unauthorized");
        }
    }



    class Program
    {
        static public int Role = 1;

        static void Main(string[] args)
        {
            OperationProxy operationProxy = new();
            operationProxy.Request();
        }
    }

}