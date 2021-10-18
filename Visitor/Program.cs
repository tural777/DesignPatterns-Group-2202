using System;

namespace Visitor
{
    class MobilePhone
    {
        public string Model { get; set; }

        public MobilePhone(string model)
        {
            Model = model;
        }

        // public void TakeAPhoto(){}

        public void Accept(IMobileVisitor visitor) => visitor.Visit(this);
    }

    class IphoneX : MobilePhone
    {
        public IphoneX() : base("IphoneX") { }
    }

    class Mi8 : MobilePhone
    {
        public Mi8() : base("Mi8") { }
    }

    class Nokia3310 : MobilePhone
    {
        public Nokia3310() : base("Nokia3310") { }
    }

    interface IMobileVisitor
    {
        void Visit(MobilePhone mobilePhone);
    }

    class PhotoVisitor : IMobileVisitor
    {
        public void Visit(MobilePhone mobilePhone)
        {
            Console.WriteLine($"{mobilePhone.Model} telefonu ile shekil chekildi");
        }
    }

    class SnakeGameVisitor : IMobileVisitor
    {
        public void Visit(MobilePhone mobilePhone)
        {
            Console.WriteLine($"{mobilePhone.Model} telefonu ile ilan oyunu oynanilir");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            PhotoVisitor photoVisitor = new();

            IphoneX iphoneX = new();
            iphoneX.Accept(photoVisitor);

            Mi8 mi8 = new Mi8();
            mi8.Accept(photoVisitor);



            SnakeGameVisitor snakeGameVisitor = new();

            Nokia3310 nokia3310 = new();
            nokia3310.Accept(snakeGameVisitor);
        }
    }
}