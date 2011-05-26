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

namespace Dotnet.Samples.Extensions
{
    #region References
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;
    #endregion

    /// <summary>
    /// A simple serializable class that represents a book.
    /// </summary>
    [DataContract, Serializable, XmlRoot("book")]
    public class Book
    {
        [DataMember, XmlAttribute("isbn")]
        public string Isbn { get; set; }
        [DataMember, XmlAttribute("title")]
        public string Title { get; set; }
        [DataMember, XmlAttribute("author")]
        public string Author { get; set; }
        [DataMember, XmlAttribute("publisher")]
        public string Publisher { get; set; }
        [DataMember, XmlAttribute("publication")]
        public DateTime Publication { get; set; }
        [DataMember, XmlAttribute("pages")]
        public int Pages { get; set; }

        public Book()
        {

        }
    }

    /// <summary>
    /// A simple serializable class that represents a catalog of books.
    /// </summary>
    [DataContract, Serializable, XmlRoot("books"), XmlType("books")]
    public class Catalog
    {
        private List<Book> books = new List<Book>();
        [DataMember, XmlElement("book")]
        public List<Book> Books { get { return books; } }
    }
}
