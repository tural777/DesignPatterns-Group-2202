using System;

namespace State // Vəziyyət
{
    interface IState
    {
        void Do(Television tv);
    }

    class Television
    {
        public IState State { get; set; }

        public Television()
        {
            State = new OffState();
        }

        public void PressToggleButton() => State.Do(this);
    }


    class OffState : IState
    {
        public void Do(Television tv)
        {
            Console.WriteLine("Televizor achildi");
            tv.State = new OnState();
        }
    }

    class OnState : IState
    {
        public void Do(Television tv)
        {
            Console.WriteLine("Televizor baglandi");
            tv.State = new OffState();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Television tv = new Television();

            tv.PressToggleButton();
            tv.PressToggleButton();
            tv.PressToggleButton();
            tv.PressToggleButton();
        }
    }
}