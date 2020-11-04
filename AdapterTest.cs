using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternTest
{
    [TestClass]
    public class AdapterTest
    {
        [TestMethod]
        public void ClassAdapterTest()
        {
            Print p = new PrintBanner("Hello");
            string weak =  p.PrintWeak();
            string strong =  p.PrintStrong();
        }
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

    public interface Print
    {
        string PrintWeak();

        string PrintStrong();
    }

    public class PrintBanner : Banner, Print
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
}
