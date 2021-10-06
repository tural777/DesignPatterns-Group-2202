using System;

namespace Prototype
{

    // Way 1

    interface IPrototype
    {
        IPrototype Clone();
    }

    class Car : IPrototype
    {
        public string Vendor { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Car() { }

        public Car(Car prototype)
        {
            Vendor = prototype.Vendor;
            Model = prototype.Model;
            Year = prototype.Year;
        }

        public IPrototype Clone() => new Car(this);
    }



    //// Optional
    //class SportCar : Car
    //{
    //    public string Field { get; set; }
        
    //    public SportCar(SportCar prototype):base(prototype)
    //    {
    //        Field = prototype.Field;
    //    }

    //    public new IPrototype  Clone() => new SportCar(this);
    //}






    //// Way 2
    //class Car : ICloneable
    //{
    //    public string Vendor { get; set; }
    //    public string Model { get; set; }
    //    public int Year { get; set; }

    //    public Car() { }

    //    public Car(Car prototype)
    //    {
    //        Vendor = prototype.Vendor;
    //        Model = prototype.Model;
    //        Year = prototype.Year;
    //    }

    //    public object Clone() => new Car(this);
    //}


    class Program
    {
        static void Main(string[] args)
        {
            //Car car = new Car { Vendor = "Kia", Model = "Cerato", Year = 2014 };
            //Car copyCar = car.Clone() as Car;

            ////car.Model = "Shallow Copy";
            //car.Model = "Deep Copy";

            //Console.WriteLine(car.Model);
            //Console.WriteLine(copyCar.Model);





            //string s1 = "Hakuna";
            //string s2 = s1.Clone().ToString();

            //Console.WriteLine(s1);
            //Console.WriteLine(s2);
        }
    }
}