using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace DesignPatternTest
{
    [TestClass]
    public class IteratorTest
    {
        #region Iterator
        /*
        [TestMethod]
        public void Iterator()
        {
            BookShelf bookShelf = new BookShelf();
            bookShelf.AppendBook(new Book("Around the world in 80 days"));
            bookShelf.AppendBook(new Book("Bible"));
            bookShelf.AppendBook(new Book("Cinderella"));
            bookShelf.AppendBook(new Book("Daddy-Long-Legs"));
            IIterator it = bookShelf.Iterator();
            while (it.HasNext())
            {
                Book book = (Book)it.Next();
                // Console.WriteLine(book.Name);
            }
        }

        public interface IAggregate
        {
            IIterator Iterator();
        }

        // 数え上げ、スキャンを表すインターフェース
        public interface IIterator
        {
            bool HasNext();

            object Next();
        }

        // 本を表すクラス
        public class Book
        {
            public string Name { get; set; }

            public Book(string name)
            {
                this.Name = name;
            }
        }

        public class BookShelf : IAggregate
        {
            List<Book> Books = new List<Book>();

            int Last { get; set; } = 0;

            public Book GetBookAt(int index)
            {
                return Books[index];
            }

            public void AppendBook(Book book)
            {
                this.Books.Add(book);
                Last++;
            }

            public int GetLength()
            {
                return this.Last;
            }

            public IIterator Iterator()
            {
                return new BookShelfIterator(this);
            }
        }

        public class BookShelfIterator : IIterator
        {
            BookShelf BookShelf { get; set; }

            int Index { get; set; }

            public BookShelfIterator(BookShelf bookShelf)
            {
                this.BookShelf = bookShelf;
                this.Index = 0;
            }

            public bool HasNext()
            {
                if (Index < BookShelf.GetLength())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public object Next()
            {
                Book book = BookShelf.GetBookAt(Index);
                this.Index++;
                return book;
            }
        }
        */
        #endregion

        
        #region Generics Iterator
        [TestMethod]
        public void GenericsIteratorTest()
        {
            BookShelf bookShelf = new BookShelf();
            bookShelf.AppendBook(new Book("Around the world in 80 days"));
            bookShelf.AppendBook(new Book("Bible"));
            bookShelf.AppendBook(new Book("Cinderella"));
            bookShelf.AppendBook(new Book("Daddy-Long-Legs"));
            IIterator<Book> it = bookShelf.Iterator();
            while (it.HasNext())
            {
                Book book = it.Next(); // 問題点：Book型のキャストをなくすには？
                Debug.WriteLine(book.Name);
            }
        }

        [TestMethod]
        public void GenericsIteratorTest2()
        {
            CdRack cdRack = new CdRack();
            cdRack.AppendCd(new Cd("Thriller"));
            cdRack.AppendCd(new Cd("Back in Black"));
            cdRack.AppendCd(new Cd("Bat out of Hell"));
            cdRack.AppendCd(new Cd("The Dark Side of the Moon"));
            IIterator<Cd> it = cdRack.Iterator();
            while (it.HasNext())
            {
                Cd cd = it.Next();
                Debug.WriteLine(cd.Title);
            }
        }

        #region 共通部品 T型の型パラメータを定義
        public interface IAggregate<T> // 2.共通部品にT型の型パラメータを定義する
        {
            IIterator<T> Iterator();
        }

        // 数え上げ、スキャンを表すインターフェース
        public interface IIterator<T> // 2.共通部品にT型の型パラメータを定義する
        {
            bool HasNext();

            T Next(); // 1.Nextメソッドの戻り値をobject型からT型にする
        }
        #endregion 共通部品

        #region 本
        // 本を表すクラス
        public class Book
        {
            public string Name { get; set; }

            public Book(string name)
            {
                this.Name = name;
            }
        }

        public class BookShelf : IAggregate<Book> // 3.共通部品の型パラメータにBookを入れる
        {
            List<Book> Books = new List<Book>();

            int Last { get; set; } = 0;

            public Book GetBookAt(int index)
            {
                return Books[index];
            }

            public void AppendBook(Book book)
            {
                this.Books.Add(book);
                Last++;
            }

            public int GetLength()
            {
                return this.Last;
            }

            public IIterator<Book> Iterator()
            {
                return new BookShelfIterator(this);
            }
        }

        public class BookShelfIterator : IIterator<Book> // 3.共通部品の型パラメータにBookを入れる
        {
            BookShelf BookShelf { get; set; }

            int Index { get; set; }

            public BookShelfIterator(BookShelf bookShelf)
            {
                this.BookShelf = bookShelf;
                this.Index = 0;
            }

            public bool HasNext()
            {
                if (Index < BookShelf.GetLength())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public Book Next()
            {
                Book book = BookShelf.GetBookAt(Index);
                this.Index++;
                return book;
            }
        }
        #endregion 本

        #region CD
        // CDを表すクラス
        public class Cd
        {
            public string Title;

            public Cd(string name)
            {
                this.Title = name;
            }
        }

        public class CdRack : IAggregate<Cd>
        {
            List<Cd> Cds = new List<Cd>();

            int Last { get; set; } = 0;

            public Cd GetCdAt(int index)
            {
                return Cds[index];
            }

            public void AppendCd(Cd cd)
            {
                this.Cds.Add(cd);
                Last++;
            }

            public int GetLength()
            {
                return this.Last;
            }

            public IIterator<Cd> Iterator()
            {
                return new CdRackIterator(this);
            }
        }

        public class CdRackIterator : IIterator<Cd>
        {
            CdRack CdRack { get; set; }

            int Index { get; set; }

            public CdRackIterator(CdRack cdRack)
            {
                this.CdRack = cdRack;
                this.Index = 0;
            }

            public bool HasNext()
            {
                if(Index < CdRack.GetLength())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public Cd Next()
            {
                Cd cd = CdRack.GetCdAt(Index);
                this.Index++;
                return cd;
            }
        }
        #endregion CD

        #endregion Iterator
    }

    
}
