using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternTest
{
    #region ClassAdapter
    [TestClass]
    public class AdapterTest
    {
        [TestMethod]
        public void ClassAdapterTest()
        {
            Print<string> p = new PrintBanner("Hello");
            string weak =  p.PrintWeak();
            string strong =  p.PrintStrong();

            Print<string> printGreeting = new PrintGreeting("山田太郎");
            string weakGreeting = printGreeting.PrintWeak();
            string strongGreeting = printGreeting.PrintStrong();
        }
        #endregion ClassAdapter

        #region ObjectAdapter
        [TestMethod]
        public void ObjectAdapterTest()
        {
            Print<string> printGreeting = new PrintGreetingAtObjectAdapter("山田太郎");
            string weakGreeting = printGreeting.PrintWeak();
            string strongGreeting = printGreeting.PrintStrong();
        }
        #endregion ObjectAdapter
    }

    public class Banner
    {
        private string Str;

        public Banner(string str)
        {
            this.Str = str;
        }
        public string ShowWithPattern()
        {
            return $"({Str})";
        }
        public string ShowWithAster()
        {
            return $"*{Str}*";
        }
    }

    public class Greeting
    {
        private string Name;

        public Greeting(string name)
        {
            this.Name = name;
        }

        public string SayHelloStrongly()
        {
            return $"{Name}さーーーん！！こーーーんにーーーちはーーーーー！！！！";
        }

        public string SayHelloWeakly()
        {
            return $"{ Name}さん...。こ、こんにちは...。";
        }
    }

    public interface Print<T>
    {
        T PrintWeak();

        T PrintStrong();
    }

    public class PrintBanner : Banner, Print<string>
    {
        public PrintBanner(string str) : base(str) { }

        public string PrintWeak()
        {
            return this.ShowWithPattern();
        }

        public string PrintStrong()
        {
            return this.ShowWithAster();
        }
    }

    public class PrintGreeting : Greeting, Print<string>
    {
        public PrintGreeting(string str) : base(str) { }

        public string PrintWeak()
        {
            return this.SayHelloWeakly();
        }

        public string PrintStrong()
        {
            return this.SayHelloStrongly();
        }
    }

    public class PrintGreetingAtObjectAdapter : Print<string>
    {
        public Greeting greeting;

        public PrintGreetingAtObjectAdapter(string name)
        {
            this.greeting = new Greeting(name);
        }

        public string PrintWeak()
        {
            return this.greeting.SayHelloWeakly();
        }

        public string PrintStrong()
        {
            return this.greeting.SayHelloStrongly();
        }
    }
}
