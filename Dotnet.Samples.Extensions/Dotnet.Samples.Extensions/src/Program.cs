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
    using System.IO;
    using System.Text;
    #endregion

    class Program
    {
        static void Main()
        {
            try
            {
                var catalog = new Catalog();
                    catalog.Books.Add(
                        new Book()
                        {
                            Isbn = "0061129739",
                            Title = "The Art of Loving",
                            Author = "Erich Fromm",
                            Publisher = "Harper Perennial Modern Classics; 15 Anv edition",
                            Publication = new DateTime(2006, 11, 21),
                            Pages = 184
                        }
                    );

                #region XML
                using (var stream = new MemoryStream())
                {
                    stream.SerializeToXml<Catalog>(catalog);
                    Console.WriteLine(Encoding.Default.GetString(stream.ToArray()));
                    Console.WriteLine(Environment.NewLine);
                }
                #endregion

                #region JSON
                using (var stream = new MemoryStream())
                {
                    stream.SerializeToJson<Catalog>(catalog);
                    Console.WriteLine(Encoding.Default.GetString(stream.ToArray()));
                    Console.WriteLine(Environment.NewLine);
                }
                #endregion
            }
            catch (Exception err)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine(String.Format("Exception: {0}", err.Message));
            }
            finally
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("Press any key to continue. . .");
                Console.ReadKey(true);
            }
        }
    }
}
