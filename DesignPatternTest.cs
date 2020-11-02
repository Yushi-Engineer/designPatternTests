﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DesignPatternTest
{
    [TestClass]
    public class DesignPatternTest
    {
        [TestMethod]
        public void IteratorTest()
        {
            BookShelf bookShelf = new BookShelf();
            bookShelf.appendBook(new Book("Around the world in 80 days"));
            bookShelf.appendBook(new Book("Bible"));
            bookShelf.appendBook(new Book("Cinderella"));
            bookShelf.appendBook(new Book("Daddy-Long-Legs"));
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
            List<Book> books = new List<Book>();

            int Last { get; set; } = 0;

            public Book GetBookAt(int index)
            {
                return books[index];
            }

            public void appendBook(Book book)
            {
                this.books.Add(book);
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
    }
}
