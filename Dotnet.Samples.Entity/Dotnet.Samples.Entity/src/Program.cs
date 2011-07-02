#region License
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

namespace Dotnet.Samples.Entity
{
    using System;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main()
        {
            try
            {
                using (var catalog = new Catalog())
                {
                    var books = from book in catalog.Books
                                where book.InStock == true
                                orderby book.Published
                                select book;

                    var txt = new StringBuilder();
                    txt.AppendLine(String.Format("{0,-37} {1,-23} {2,10} {3,5}", "-------------------------------------", "-----------------------", "----------", "-----"));
                    txt.AppendLine(String.Format("{0,-37} {1,-23} {2,-10} {3,-5}", "Title", "Author", "Published", "Pages"));
                    txt.AppendLine(String.Format("{0,-37} {1,-23} {2,10} {3,5}", "-------------------------------------", "-----------------------", "----------", "-----"));

                    foreach (var book in books)
                    {
                        txt.AppendLine(String.Format("{0,-37} {1,-23} {2,10} {3,5}", book.Title, book.Author, book.Published.ToShortDateString(), book.Pages));
                    }

                    txt.AppendLine(String.Format("{0,-37} {1,-23} {2,10} {3,5}", "-------------------------------------", "-----------------------", "----------", "-----"));
                    Console.WriteLine(txt.ToString());
                }
            }
            catch (Exception err)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine(String.Format("Exception caught: {0}", err.Message));
            }
            finally
            {
                Console.Write(Environment.NewLine);
                Console.Write("Press any key to continue . . .");
                Console.ReadKey(true);
            }
        }
    }
}
