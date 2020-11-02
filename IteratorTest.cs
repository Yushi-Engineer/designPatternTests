using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
        public void GenericsIterator()
        {
            BookShelf bookShelf = new BookShelf();
            bookShelf.AppendBook(new Book("Around the world in 80 days"));
            bookShelf.AppendBook(new Book("Bible"));
            bookShelf.AppendBook(new Book("Cinderella"));
            bookShelf.AppendBook(new Book("Daddy-Long-Legs"));
            IIterator it = bookShelf.Iterator();
            while (it.HasNext())
            {
                object book = it.Next();
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
        #endregion
    }
}
