using System;

namespace Decorator
{
    #region Renderer
    //abstract class AbstractRenderer
    //{
    //    public abstract void RenderInformation(string text);
    //}


    //class Renderer : AbstractRenderer
    //{
    //    public override void RenderInformation(string text)
    //    {
    //        Console.WriteLine(text);
    //    }
    //}



    //class BaseDecorator : AbstractRenderer
    //{
    //    protected AbstractRenderer _renderer { get; set; }

    //    public BaseDecorator(AbstractRenderer renderer)
    //    {
    //        _renderer = renderer;
    //    }

    //    public override void RenderInformation(string text)
    //    {
    //        _renderer.RenderInformation(text);
    //    }
    //}


    //class ColorDecorator : BaseDecorator
    //{
    //    private ConsoleColor _color { get; set; }

    //    public ColorDecorator(AbstractRenderer renderer, ConsoleColor color) : base(renderer)
    //    {
    //        _color = color;
    //    }


    //    public override void RenderInformation(string text)
    //    {
    //        var oldColor = Console.ForegroundColor;
    //        Console.ForegroundColor = _color;
    //        _renderer.RenderInformation(text);
    //        Console.ForegroundColor = oldColor;
    //    }
    //}


    //class UnderlineDecorator : BaseDecorator
    //{
    //    public UnderlineDecorator(AbstractRenderer renderer):base(renderer){}

    //    public override void RenderInformation(string text)
    //    {
    //        _renderer.RenderInformation(text);

    //        foreach (var item in text)
    //        {
    //            Console.Write("-");
    //        }

    //        Console.WriteLine();
    //    }
    //}



    //class UpperCaseDecorator : BaseDecorator
    //{
    //    public UpperCaseDecorator(AbstractRenderer renderer):base(renderer){}

    //    public override void RenderInformation(string text)
    //    {
    //        _renderer.RenderInformation(text.ToUpper());
    //    }
    //}





    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        AbstractRenderer renderer = new Renderer();
    //        renderer.RenderInformation("Salam");

    //        renderer = new ColorDecorator(renderer, ConsoleColor.Red);
    //        renderer.RenderInformation("Salam");

    //        //renderer = new UnderlineDecorator(renderer);
    //        //renderer.RenderInformation("Salam");

    //        renderer = new UpperCaseDecorator(renderer);
    //        renderer.RenderInformation("Salam");

    //    }
    //}

    #endregion


    #region Notifier
    interface INotifier
    {
        public void Send(string message);
    }


    class Notifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine("Message sent with Email"); ;
        }
    }

    abstract class BaseDecorator : INotifier
    {
        protected INotifier _notifier { get; set; }

        public BaseDecorator(INotifier notifier)
        {
            _notifier = notifier;
        }

        public virtual void Send(string message)
        {
            _notifier.Send(message);
        }
    }


    class TelegramDecorator : BaseDecorator
    {
        public TelegramDecorator(INotifier notifier):base(notifier){}
        
        public override void Send(string message)
        {
            // hard code
            base.Send(message);
            Console.WriteLine("Message sent with Telegram");
        }
    }


    class FacebookDecorator : BaseDecorator
    {
        public FacebookDecorator(INotifier notifier) : base(notifier) { }

        public override void Send(string message)
        {
            // hard code
            base.Send(message);
            Console.WriteLine("Message sent with Facebook");
        }
    }


    class SlackDecorator : BaseDecorator
    {
        public SlackDecorator(INotifier notifier) : base(notifier) { }

        public override void Send(string message)
        {
            // hard code
            base.Send(message);
            Console.WriteLine("Message sent with Slack");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            INotifier notifier = new Notifier();

            notifier = new TelegramDecorator(notifier);
            notifier = new FacebookDecorator(notifier);
            notifier = new SlackDecorator(notifier);

            notifier.Send("Discount 50%");
        }
    }
    #endregion
}