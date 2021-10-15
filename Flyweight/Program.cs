using System;
using System.Collections.Generic;

namespace FlyWeight
{
    abstract class UnitFlyWeight
    {
        protected string Name;
        protected int AttackPoint;
        protected int Health;

        public abstract void Display();
    }


    class Archer : UnitFlyWeight
    {
        public Archer()
        {
            Name = "Archer";
            AttackPoint = 90;
            Health = 540;
        }

        public override void Display()
        {
            Console.Write("Archer created");
        }
    }

    class Warrior : UnitFlyWeight
    {
        public Warrior()
        {
            Name = "Warrior";
            AttackPoint = 50;
            Health = 900;
        }

        public override void Display()
        {
            Console.Write("Warrior created");
        }
    }



    class FlyWeightFactory
    {
        private Dictionary<string, UnitFlyWeight> _units = new();

        public UnitFlyWeight GetUnit(string key)
        {
            UnitFlyWeight unit = null;

            if (_units.ContainsKey(key))
            {
                unit = _units[key];
            }
            else
            {
                switch (key)
                {
                    case "Archer":
                        unit = new Archer();
                        break;
                    case "Warrior":
                        unit = new Warrior();
                        break;
                }

                _units.Add(key, unit);
            }

            return unit;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            FlyWeightFactory factory = new FlyWeightFactory();

            List<UnitFlyWeight> units = new List<UnitFlyWeight>();

            for (int i = 0; i < 1000000; i++)
            {
                //Archer unit = new Archer();
                //Warrior unit1 = new Warrior();

                UnitFlyWeight unit = factory.GetUnit("Archer");
                UnitFlyWeight unit1 = factory.GetUnit("Warrior");


                //unit.Display();

                //Console.Write(unit.GetHashCode());

                units.Add(unit);
                units.Add(unit1);
            }

            Console.ReadKey();
        }
    }

}