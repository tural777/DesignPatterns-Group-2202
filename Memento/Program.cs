using System;

namespace Memento // Xatirə
{
    // Also known as: Snapshot - Anlık görüntü

    // Originator - Yaratıcı
    // Memento - Xatirə
    // Caretaker - Gözətçi



    // Originator
    class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move()
        {
            X++;
            Y++;
        }

        public override string ToString()
        {
            return $"x: {X},  y: {Y}";
        }



        public void Setup(CoordinateMemento memento)
        {
            X = memento.X;
            Y = memento.Y;
        }

        public CoordinateMemento BackUp()
        {
            return new(X, Y);
        }
    }



    // Memento
    class CoordinateMemento
    {
        public int X { get; set; }
        public int Y { get; set; }

        public CoordinateMemento(int x, int y)
        {
            X = x;
            Y = y;
        }
    }


    // Caretaker
    class CoordinateCaretaker
    {
        public CoordinateMemento Memento { get; set; }
    }




    class Program
    {
        static void Main(string[] args)
        {
            Coordinate coordinate = new Coordinate(15, 15);
            coordinate.Move();
            Console.WriteLine(coordinate);


            CoordinateCaretaker caretaker = new CoordinateCaretaker
            {
                Memento = coordinate.BackUp()
            };


            coordinate.Move();
            coordinate.Move();
            coordinate.Move();

            Console.WriteLine(coordinate);


            coordinate.Setup(caretaker.Memento);
            Console.WriteLine(coordinate);
        }
    }
}