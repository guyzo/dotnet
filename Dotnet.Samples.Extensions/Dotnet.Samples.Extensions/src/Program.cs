﻿#region License
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
    using System.IO;
    using System.Text;
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Sample serializable data

                Catalog catalog = new Catalog();

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

                // XML serialization sample

                using (MemoryStream persistence = new MemoryStream())
                {
                    persistence.SerializeToXml<Catalog>(catalog);
                    Console.WriteLine(Encoding.Default.GetString(persistence.ToArray()));
                }

                Console.WriteLine(Environment.NewLine);

                // JSON serialization sample

                using (MemoryStream persistence = new MemoryStream())
                {
                    persistence.SerializeToJson<Catalog>(catalog);
                    Console.WriteLine(Encoding.Default.GetString(persistence.ToArray()));
                }

                Console.WriteLine(Environment.NewLine);
            
            }
            catch (Exception error)
            {
                Console.WriteLine("Error: " + error.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to continue. . .");
                Console.ReadKey(true);
            }
        }
    }
}
