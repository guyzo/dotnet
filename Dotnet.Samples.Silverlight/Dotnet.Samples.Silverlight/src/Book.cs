#region License
// Copyright (c) 2010 Nano Taboada, http://openid.nanotaboada.com.ar
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
#endregion

namespace Dotnet.Samples.Silverlight
{
    #region References
    using System;
    using System.Collections.Generic;
    #endregion

    public class Book
    {
        #region Properties
        public string Isbn10 { get; set; }
        public string Isbn13 { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Collaborator { get; set; }
        public string Publisher { get; set; }
        public DateTime Published { get; set; }
        public int? Pages { get; set; }
        public bool InStock { get; set; }
        #endregion

        public Book(string isbn10, string title, string author, string publisher, DateTime published, string isbn13 = "N/A", string collaborator = "N/A", int? pages = null, bool instock = true)
        {
            this.Isbn10 = isbn10;
            this.Isbn13 = isbn13;
            this.Title = title;
            this.Author = author;
            this.Collaborator = collaborator;
            this.Publisher = publisher;
            this.Published = published;
            this.Pages = pages;
            this.InStock = instock;
        }
    }

    public static class BookExtensions
    {
        public static List<Book> AddBooks(this List<Book> books)
        {
            books.Add(new Book("0385418868", "The Power of Myth", "Joseph Campbell", "Anchor", new DateTime(1991, 6, 1), collaborator: "Bill Moyers", pages: 293));
            books.Add(new Book("1577315936", "The Hero with a Thousand Faces", "Joseph Campbell", "New World Library", new DateTime(2008, 7, 28), pages: 432));
            books.Add(new Book("1577312023", "Thou Art That", "Joseph Campbell", "New World Library", new DateTime(2001, 10, 10), pages: 192));
            books.Add(new Book("1577312090", "The Inner Reaches of Outer Space", "Joseph Campbell", "New World Library", new DateTime(2002, 2, 9), pages: 160));
            books.Add(new Book("1577314034", "Myths of Light", "Joseph Campbell", "New World Library", new DateTime(2003, 5, 1), pages: 224));
            books.Add(new Book("1577314719", "Pathways to Bliss", "Joseph Campbell", "New World Library", new DateTime(2004, 10, 26), pages: 224));

            return books;
        }
    }
}

