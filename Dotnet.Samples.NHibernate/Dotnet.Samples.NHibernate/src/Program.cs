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

#region References
using System;
using System.IO;
using System.Reflection;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
#endregion

/// <remarks>
/// INFO:
/// - The 'Copy Local' property of the referenced database assembly
///   'System.Data.SqlServerCe' should be set to 'True'.
/// - The 'Build Action' property of either the mapping configuration file
///   'Book.hbm.xml' and its associated schema 'nhibernate-mapping.xsd' should
///   be set to 'Embedded Resource'.
/// - The mapped classes should have their 'lazy' attribute set to 'false'. 
/// </remarks>

namespace Dotnet.Samples.NHibernate
{
    class Program
    {
        static void Main()
        {
            try
            {
                var asm = Assembly.GetExecutingAssembly().Location;
                var xml = Path.Combine(Path.GetDirectoryName(asm), "cfg", "hibernate.cfg.xml");
                var cfg = new Configuration();
                    cfg.Configure(xml);
                    cfg.AddAssembly(typeof(Book).Assembly);
                var hbm = new SchemaExport(cfg);

                ISessionFactory isf = cfg.BuildSessionFactory();

                using (ISession session = isf.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        // INFO: ISBN-10 format pattern should be #-###-#####-#
                        var isbn = "0596800959";

                        // INFO: Performing Read for simplicity but could be any CRUD operation.
                        var book = session.Get<Book>(isbn);

                        if (book != null)
                        {
                            var txt = new StringBuilder();
                                txt.AppendLine(String.Format("Getting book with ISBN: {0}-{1}-{2}-{3}", isbn.Substring(0,1), isbn.Substring(1,3), isbn.Substring(4,5), isbn.Substring(9,1)));
                                txt.Append(System.Environment.NewLine);
                                txt.AppendLine(String.Format("{0,-37} {1,-23} {2,10} {3,5}", "-".Repeat(37), "-".Repeat(23), "-".Repeat(10), "-".Repeat(5)));
                                txt.AppendLine(String.Format("{0,-37} {1,-23} {2,-10} {3,-5}", "Title", "Author", "Published", "Pages"));
                                txt.AppendLine(String.Format("{0,-37} {1,-23} {2,10} {3,5}", "-".Repeat(37), "-".Repeat(23), "-".Repeat(10), "-".Repeat(5)));
                                txt.AppendLine(String.Format("{0,-37} {1,-23} {2,10} {3,5}", book.Title, book.Author, book.Published.ToShortDateString(), book.Pages));
                                txt.AppendLine(String.Format("{0,-37} {1,-23} {2,10} {3,5}", "-".Repeat(37), "-".Repeat(23), "-".Repeat(10), "-".Repeat(5)));

                            Console.Write(txt.ToString());
                        }
                    }
                }
            }
            catch (Exception err)
            {
                Console.Write(System.Environment.NewLine);
                Console.WriteLine(String.Format("Exception: {0}", err.Message));
                if (err.InnerException.Message.Length > 0)
                {
                    Console.WriteLine(String.Format("InnerException: {0}", err.InnerException.Message));   
                }
            }
            finally
            {
                Console.Write(System.Environment.NewLine);
                Console.Write("Press any key to continue . . .");
                Console.ReadKey(true);
            }
        }
    }
}
