using System;

namespace AbstractFactory
{
    interface IChair
    {
        bool HasLegs();
        bool SitOn();
    }
    
    class VictorianChair : IChair
    {
        public VictorianChair()
        {
            Console.WriteLine("Victorian Chair");
        }

        public bool HasLegs() => true;
        public bool SitOn() => true;
    }

    class ModernChair : IChair
    {
        public ModernChair()
        {
            Console.WriteLine("Modern Chair");
        }

        public bool HasLegs() => false;
        public bool SitOn() => false;
    }

    class ArtDecoChair : IChair
    {
        public ArtDecoChair()
        {
            Console.WriteLine("ArtDeco Chair");
        }

        public bool HasLegs() => false;
        public bool SitOn() => false;
    }



    interface ICoffeTable
    {
        bool CanOpen();
        bool CanRotate();
    }

    class VictorianCoffeTable : ICoffeTable
    {
        public VictorianCoffeTable()
        {
            Console.WriteLine("Victorian CoffeTable");
        }

        public bool CanOpen() => true;
        public bool CanRotate() => true;
    }

    class ModernCoffeTable : ICoffeTable
    {
        public ModernCoffeTable()
        {
            Console.WriteLine("Modern CoffeTable");
        }

        public bool CanOpen() => false;
        public bool CanRotate() => false;
    }

    class ArtDecoCoffeTable : ICoffeTable
    {
        public ArtDecoCoffeTable()
        {
            Console.WriteLine("ArtDeco CoffeTable");
        }

        public bool CanOpen() => false;
        public bool CanRotate() => false;
    }




    interface ISofa
    {
        bool HasCorner();
        bool CanOpen();
    }

    class VictorianSofa : ISofa
    {
        public VictorianSofa()
        {
            Console.WriteLine("Victorian Sofa");
        }

        public bool CanOpen() => true;
        public bool HasCorner() => true;
    }

    class ModernSofa : ISofa
    {
        public ModernSofa()
        {
            Console.WriteLine("Modern Sofa");
        }

        public bool CanOpen() => false;
        public bool HasCorner() => false;
    }

    class ArtDecoSofa : ISofa
    {
        public ArtDecoSofa()
        {
            Console.WriteLine("ArtDeco Sofa");
        }

        public bool CanOpen() => false;
        public bool HasCorner() => false;
    }

    
    interface IFurnitureFactory
    {
        IChair CreateChair();
        ICoffeTable CreateCoffeTable();
        ISofa CreateSofa();
    }

    class VictorianFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair() => new VictorianChair();

        public ICoffeTable CreateCoffeTable() => new VictorianCoffeTable();

        public ISofa CreateSofa() => new VictorianSofa();
    }

    class ModernFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair() => new ModernChair();

        public ICoffeTable CreateCoffeTable() => new ModernCoffeTable();

        public ISofa CreateSofa() => new ModernSofa();
    }

    class ArtDecoFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair() => new ArtDecoChair();

        public ICoffeTable CreateCoffeTable() => new ArtDecoCoffeTable();

        public ISofa CreateSofa() => new ArtDecoSofa();
    }



    class Program
    {
        static void Main(string[] args)
        {
            IFurnitureFactory furnitureFactory = new ArtDecoFurnitureFactory();
            furnitureFactory.CreateChair();
            furnitureFactory.CreateCoffeTable();
            furnitureFactory.CreateSofa();
        }
    }
}
