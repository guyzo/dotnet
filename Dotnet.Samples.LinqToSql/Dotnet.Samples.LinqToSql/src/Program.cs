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

namespace Dotnet.Samples.LinqToSql
{
    #region References
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    #endregion

    class Program
    {
        static void Main()
        {
            try
            {
                ///<remarks>
                /// Northwind sample database is available to download from http://goo.gl/QCrEk
                /// Make sure that SQL Server service is running and Northwind.mdf is attached.
                /// (Server Explorer -> Data Connections -> Northwind.mdf -> [Right-click] -> Refresh)
                ///</remarks>

                var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                var mdf = Path.Combine(Path.Combine(dir, "res"), "Northwind.mdf");
                var con = new SqlConnectionStringBuilder();
                con.DataSource = @".\SQLEXPRESS";
                con.AttachDBFilename = mdf;

                using (var data = new NorthwindDataContext(con.ConnectionString))
                {
                    var value = "Buenos Aires";
                    var query = from q in data.Customers
                                where q.City == value
                                select q;

                    if (query != null)
                    {
                        Console.WriteLine("-----  ----------------------------------");
                        Console.WriteLine("Id     Company Name");
                        Console.WriteLine("-----  ----------------------------------");

                        foreach (var record in query)
                        {
                            Console.WriteLine("{0}  {1}", record.CustomerID, record.CompanyName);
                        }

                        Console.WriteLine("-----  ----------------------------------");
                    }
                    else
                    {
                        Console.WriteLine(String.Format("Your query - {0} - did not match any records.", value));
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(String.Format("Exception caught: {0}", err.Message));
            }
            finally
            {
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey(true);
            }
        }
    }
}
