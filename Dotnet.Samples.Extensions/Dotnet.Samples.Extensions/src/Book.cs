﻿#region License
// Copyright (c) 2011 Nano Taboada, http://openid.nanotaboada.com.ar
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
    [Serializable, XmlRoot("book"), DataContract]
    public class Book
    {
        [XmlAttribute("isbn"), DataMember]
        public string Isbn { get; set; }
        [XmlAttribute("title"), DataMember]
        public string Title { get; set; }
        [XmlAttribute("author"), DataMember]
        public string Author { get; set; }
        [XmlAttribute("publisher"), DataMember]
        public string Publisher { get; set; }
        [XmlAttribute("publication"), DataMember]
        public DateTime Publication { get; set; }
        [XmlAttribute("pages"), DataMember]
        public int Pages { get; set; }

        public Book()
        {

        }
    }
}
