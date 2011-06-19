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

namespace Dotnet.Samples.LinqToXml
{
    #region References
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Linq;
    #endregion

    class Program
    {
        static void Main()
        {
            try
            {
                // Sample XML file (books.xml) is available to be downloaded from:
                // http://msdn.microsoft.com/en-us/library/ms762271%28VS.85%29.aspx

                var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                var res = Path.Combine(Path.Combine(dir, "res"), "books.xml");
                var xml = XDocument.Load(res);
                
                var books = from b in xml.Descendants("book")
                            select new
                            { 
                                Id = b.Attribute("id").Value,
                                Title = b.Element("title").Value,
                                Author = b.Element("author").Value,
                                Genre = b.Element("genre").Value,
                                Price = b.Element("price").Value,
                                Published = b.Element("publish_date").Value
                            };

                // INFO: notice that books is IEnumerable<anonymous>
                if (books != null)
                {
                    Console.WriteLine("1. Created by loading the XML file, displaying first 3 elements:");
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("{0,-25} {1,-25} {2,-15} {3,10}", "-------------------------", "-------------------------", "---------------", "----------");
                    Console.WriteLine("{0,-25} {1,-25} {2,-15} {3,-10}", "Title", "Author", "Published", "Price");
                    Console.WriteLine("{0,-25} {1,-25} {2,-15} {3,10}", "-------------------------", "-------------------------", "---------------", "----------");

                    // INFO: Just taking first 3 elements to fit default console window size (80x25)
                    foreach (var book in books.Take(3))
                    {
                        Console.WriteLine("{0,-25} {1,-25} {2,-15} {3,10}", book.Title, book.Author, book.Published, book.Price);
                    }

                    Console.WriteLine("{0,-25} {1,-25} {2,-15} {3,10}", "-------------------------", "-------------------------", "---------------", "----------");
                }

                Console.Write(Environment.NewLine);
                Console.WriteLine("2. Made taking advantage of LINQ to XML functional construction:");

                XDocument doc = new XDocument(
                    new XDeclaration("1.0", "UTF-8", "yes"),
                    new XElement("catalog",
                        new XElement("book",
                            new XAttribute("id", "bk999"),
                            new XElement("author", "Doe, John"),
                            new XElement("title", "Lorem Ipsum"),
                            new XElement("genre", "Miscellaneous"),
                            new XElement("price", "42"),
                            new XElement("publish_date", DateTime.Now.ToShortDateString()),
                            new XElement("description", "The quick brown fox jumps over the lazy dog.")
                        )
                    )
                );

                Console.Write(Environment.NewLine);
                Console.WriteLine(doc.ToString());
            }
            catch (Exception err)
            {
                Console.WriteLine(String.Format("Exception caught: {0}", err.Message));
            }
            finally
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey(true);
            }
        }
    }
}
