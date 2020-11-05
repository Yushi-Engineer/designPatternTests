using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace DesignPatternTest
{
    [TestClass]
    public class AdapterTest
    {
        #region ClassAdapter
        [TestMethod]
        public void ClassAdapterTest()
        {
            Print<string> p = new PrintBanner("Hello");
            string weak =  p.PrintWeak();
            string strong =  p.PrintStrong();
            Debug.WriteLine(weak);
            Debug.WriteLine(strong);

            Print<string> printGreeting = new PrintGreeting("山田太郎");
            string weakGreeting = printGreeting.PrintWeak();
            string strongGreeting = printGreeting.PrintStrong();
            Debug.WriteLine(weakGreeting);
            Debug.WriteLine(strongGreeting);
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

        /// <summary>
        /// アダプタークラス
        /// </summary>
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

        /// <summary>
        /// アダプタークラス
        /// </summary>
        public class PrintGreetingAtObjectAdapter : Print<string>
        {
            public Greeting Greeting;

            public PrintGreetingAtObjectAdapter(string name)
            {
                this.Greeting = new Greeting(name);
            }

            public string PrintWeak()
            {
                return this.Greeting.SayHelloWeakly();
            }

            public string PrintStrong()
            {
                return this.Greeting.SayHelloStrongly();
            }
        }
    }
}
