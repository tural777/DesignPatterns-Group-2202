using System;
using System.Collections.Generic;

namespace Facade
{
    interface IDevice
    {
        string Vendor { get; set; }
        string Model { get; set; }

        void Start();
    }

    class CPU : IDevice
    {
        public string Vendor { get; set; }
        public string Model { get; set; }

        public void Start()
        {
            Console.WriteLine("CPU started");
        }
    }


    class RAM : IDevice
    {
        public string Vendor { get; set; }
        public string Model { get; set; }

        public void Start()
        {
            Console.WriteLine("RAM started");
        }
    }

    class GPU : IDevice
    {
        public string Vendor { get; set; }
        public string Model { get; set; }

        public void Start()
        {
            Console.WriteLine("GPU started");
        }
    }

    class MotherBoard : IDevice
    {
        public string Vendor { get; set; }
        public string Model { get; set; }

        public void Start()
        {
            Console.WriteLine("Motherboard started");
        }

    }

    class PowerSupply : IDevice
    {
        public string Vendor { get; set; }
        public string Model { get; set; }

        public void Start()
        {
            Console.WriteLine("PowerSupply started");
        }
    }

    class Case : IDevice
    {
        public List<IDevice> Devices { get; set; } = new();

        public string Vendor { get; set; }
        public string Model { get; set; }

        public void AddDevice(IDevice _otherdevice)
        {
            Devices.Add(_otherdevice);
        }

        public void Start()
        {
            Devices.ForEach(e => e.Start());
            Console.WriteLine("Computer started");
        }
    }


    class ComputerFacade
    {
        MotherBoard mb = new MotherBoard();
        RAM ram = new RAM();
        GPU gpu = new GPU();
        CPU cpu = new CPU();
        PowerSupply ps = new PowerSupply();
        Case c = new Case();

        public void Start()
        {
            // some hard code 

            c.AddDevice(mb);
            c.AddDevice(ram);
            c.AddDevice(gpu);
            c.AddDevice(cpu);
            c.AddDevice(ps);

            c.Start();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            ComputerFacade facade = new ComputerFacade();
            facade.Start();
        }
    }
}