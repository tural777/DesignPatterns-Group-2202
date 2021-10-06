using System;

namespace Singleton
{
    class President
    {
        public string Name { get; set; }
        public string Surname { get; set; } 
        public int Height { get; set; }

        private President(){}

        private static President _instance;


        //// Way 1
        //public static President GetInstance()
        //{
        //    if (_instance == null)
        //    {
        //        _instance = new President { Name = "XXX", Surname = "XXX", Height = 195 };
        //    }

        //    return _instance;
        //}


        // Way 2
        static public President Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new President { Name = "XXX", Surname = "XXX", Height = 195 };
                }

                return _instance;
            }
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            President president = President.Instance;
            President ok = President.Instance;


            Console.WriteLine(president.Name);
        }
    }
}
