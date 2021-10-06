using System;
using System.Text;

namespace Builder
{
    // Product
    // Builder
    // Builder : Concrete
    // Director


    class Home
    {
        public string Name { get; set; }
        public int Walls { get; set; }
        public int Garage { get; set; }
        public int Garden { get; set; }
        public int Pool { get; set; }
        public int Window { get; set; }
        public int Door { get; set; }
        public bool HasRoof { get; set; }

        public override string ToString() => @$"
        Name: {Name}
        Walls: {Walls}
        Garage: {Garage}
        Garden: {Garden}
        Pool: {Pool}
        Window: {Window}
        Door: {Door}
        HasRoof: {HasRoof}";
    }


    interface IBuilder
    {
        public Home Home { get; set; }

        IBuilder Reset();

        IBuilder BuildWalls();
        IBuilder BuildGarage();
        IBuilder BuildGarden();
        IBuilder BuildDoors();
        IBuilder BuildRoof();
        IBuilder BuildPool();
        IBuilder BuildWindow();

        Home GetResult(); // Build
    }


    class WoodBuilder : IBuilder
    {
        public Home Home { get; set; } = new Home { Name = "Wood Home" };

        public IBuilder BuildDoors()
        {
            Home.Door = 2;
            return this;
        }

        public IBuilder BuildGarage()
        {
            Home.Garage = 1;
            return this;
        }

        public IBuilder BuildGarden()
        {
            Home.Garden = 4;
            return this;
        }

        public IBuilder BuildPool()
        {
            Home.Pool = 1;
            return this;
        }

        public IBuilder BuildRoof()
        {
            Home.HasRoof = true;
            return this;
        }

        public IBuilder BuildWalls()
        {
            Home.Walls = 8;
            return this;
        }

        public IBuilder BuildWindow()
        {
            Home.Window = 3;
            return this;
        }

        public Home GetResult() => Home;

        public IBuilder Reset()
        {
            Home = new Home();
            return this;
        }
    }

    class StoneBuilder : IBuilder
    {
        public Home Home { get; set; } = new Home { Name = "Stone Home" };

        public IBuilder BuildDoors()
        {
            Home.Door = 22;
            return this;
        }

        public IBuilder BuildGarage()
        {
            Home.Garage = 11;
            return this;
        }

        public IBuilder BuildGarden()
        {
            Home.Garden = 44;
            return this;
        }

        public IBuilder BuildPool()
        {
            Home.Pool = 11;
            return this;
        }

        public IBuilder BuildRoof()
        {
            Home.HasRoof = true;
            return this;
        }

        public IBuilder BuildWalls()
        {
            Home.Walls = 88;
            return this;
        }

        public IBuilder BuildWindow()
        {
            Home.Window = 33;
            return this;
        }

        public Home GetResult() => Home;

        public IBuilder Reset()
        {
            Home = new Home();
            return this;
        }
    }


    class Master // Director
    {
        private IBuilder _builder;

        public Master(IBuilder builder)
        {
            _builder = builder;
        }

        public void ChangeBuilder(IBuilder builder)
        {
            _builder = builder;
        }

        public Home Make(string type)
        {
            _builder.Reset();

            if (type == "A")
            {
                _builder.Home.Name = "A Category";

                return _builder
                .BuildRoof()
                .BuildGarden()
                .BuildGarage()
                .BuildDoors()
                .BuildWindow()
                .BuildWalls()
                .BuildPool()
                .GetResult();
            }
            else if (type == "B")
            {
                _builder.Home.Name = "B Category";

                return _builder
                .BuildRoof()
                .BuildGarage()
                .BuildDoors()
                .BuildWindow()
                .BuildWalls()
                .GetResult();
            }
            else if (type == "C")
            {
                _builder.Home.Name = "C Category";

                return _builder
                .BuildRoof()
                .BuildDoors()
                .BuildWindow()
                .BuildWalls()
                .GetResult();
            }

            throw new Exception("Wrong Type");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            // IBuilder builder = new StoneBuilder();

            // Home home = builder
            //     .BuildRoof()
            //     .BuildGarden()
            //     .BuildDoors()
            //     .BuildWindow()
            //     .BuildWalls()
            //     .GetResult();

            // builder.Reset();

            // Console.WriteLine(home);





            //// Director
            // IBuilder builder = new WoodBuilder();

            //Master master = new Master(builder);
            ////master.ChangeBuilder(new StoneBuilder());
            //Home home = master.Make("C");

            //Console.WriteLine(home);





            //// StringBuilder
            //StringBuilder sb = new StringBuilder();
            //sb.Append("Hakuna").Append("Matata").Append("Fluent").ToString();
        }
    }
}