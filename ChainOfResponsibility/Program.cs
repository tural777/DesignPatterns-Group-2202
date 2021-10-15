using System;

namespace ChainOfResponsibility
{
    abstract class CompilerCOR
    {
        protected CompilerCOR Next { get; set; }

        public virtual CompilerCOR SetNext(CompilerCOR next)
        {
            Next = next;
            return this;
        }

        public abstract void Handle();
    }

    class SyntaxAnalyzer : CompilerCOR
    {
        public override void Handle()
        {
            Console.WriteLine("SyntaxAnalyzer");
            Next?.Handle();
        }
    }

    class LexicalAnalyzer : CompilerCOR
    {
        public override void Handle()
        {
            Console.WriteLine("LexicalAnalyzer");
            Next?.Handle();
        }
    }

    class Linker : CompilerCOR
    {
        public override void Handle()
        {
            Console.WriteLine("Linker");
            Next?.Handle();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            CompilerCOR compiler = new SyntaxAnalyzer()
                .SetNext(new LexicalAnalyzer()
                .SetNext(new Linker()));

            compiler.Handle();
        }
    }
}