using System;

namespace Bridge
{
    interface IDevice
    {
        bool IsEnabled { get; set; }
        short Volume { get; set; }
        short Channel { get; set; }

        void Enable();
        void Disable();
    }

    class Tv : IDevice
    {
        public bool IsEnabled { get; set; }
        public short Volume { get; set; }
        public short Channel { get; set; }

        public void Enable() => IsEnabled = true;
        public void Disable() => IsEnabled = false;
    }


    class Radio : IDevice
    {
        public bool IsEnabled { get; set; }
        public short Volume { get; set; }
        public short Channel { get; set; }

        public void Enable() => IsEnabled = true;
        public void Disable() => IsEnabled = false;
    }


    class RemoteControl
    {
        protected IDevice _device { get; set; }

        public RemoteControl(IDevice device)
        {
            _device = device;
        }

        public void TogglePower() {
            if (_device.IsEnabled) _device.Disable();
            else _device.Enable();
        }

        public void VolumeUp() => _device.Volume += 10;
        public void VolumeDown() => _device.Volume -= 10;

        public void ChannelUp() => _device.Channel++;
        public void ChannelDown() => _device.Channel--;

    }


    class NeoRemote : RemoteControl
    {
        public void Mute() => _device.Volume = 0;

        public NeoRemote(IDevice device):base(device){}
    }


    class Program
    {
        static void Main(string[] args)
        {
            //var radio = new Radio();
            var tv = new Tv();
            var remote = new RemoteControl(tv);

            Console.WriteLine($"Before: {tv.IsEnabled}");
            remote.TogglePower();
            Console.WriteLine($"After: {tv.IsEnabled}");

            //remote.ChannelUp();
            //remote.ChannelDown();
            //remote.VolumeUp();
            //remote.VolumeDown();




            NeoRemote remoteNeo = new NeoRemote(tv);
            remoteNeo.VolumeUp();
            Console.WriteLine($"Before: {tv.Volume}");
            remoteNeo.Mute();
            Console.WriteLine($"After: {tv.Volume}");
        }
    }
}
