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
                    Console.WriteLine("{0,-25} {1,-25} {2,-15} {3,10}", "-------------------------", "-------------------------", "---------------", "----------");
                    Console.WriteLine("{0,-25} {1,-25} {2,-15} {3,-10}", "Title", "Author", "Published", "Price");
                    Console.WriteLine("{0,-25} {1,-25} {2,-15} {3,10}", "-------------------------", "-------------------------", "---------------", "----------");
                
                    foreach (var book in books)
                    {
                        Console.WriteLine("{0,-25} {1,-25} {2,-15} {3,10}", book.Title, book.Author, book.Published, book.Price);
                    }

                    Console.WriteLine("{0,-25} {1,-25} {2,-15} {3,10}", "-------------------------", "-------------------------", "---------------", "----------");
                }
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
