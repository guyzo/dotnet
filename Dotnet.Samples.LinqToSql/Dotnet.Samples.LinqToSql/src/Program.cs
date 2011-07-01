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

namespace Dotnet.Samples.LinqToSql
{
    #region References
    using System;
    using System.Data.SqlServerCe;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    #endregion

    class Program
    {
        static void Main()
        {
            try
            {
                ///<remarks>
                /// If you're using Visual Studio 2010 SP1 the sample database
                /// included with this solution should also be available at: 
                /// %PROGRAMFILES%\Microsoft SQL Server Compact Edition\v4.0\Samples
                ///</remarks>

                var res = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "res");
                var con = new SqlCeConnectionStringBuilder();
                con.DataSource = Path.Combine(res, "Northwind.sdf");
                
                // TODO: Create a complex LINQ expression with data from all tables.

                var msg = "Retrieving the amount of customers and orders per city in the USA:";

                using (var data = new NorthwindDataContext(con.ConnectionString))
                {
                    var query = from customer in data.Customers
                                join order in data.Orders on customer.CustomerID equals order.CustomerID
                                where customer.Country == "USA" 
                                group customer by customer.City into customerPerCity
                                select new
                                {
                                    City = customerPerCity.Key,
                                    CustomerCount = customerPerCity.Count(),
                                    OrderCount = customerPerCity.Sum(c => c.Orders.Count)
                                };

                    if (query != null)
                    {
                        var txt = new StringBuilder();
                        txt.AppendLine(msg);
                        txt.Append(Environment.NewLine);
                        txt.AppendLine(String.Format("{0,-54} {1,11} {2,11}", "------------------------------------------------------", "-----------", "-----------"));
                        txt.AppendLine(String.Format("{0,-54} {1,11} {2,11}", "City", "Customers", "Orders"));
                        txt.AppendLine(String.Format("{0,-54} {1,11} {2,11}", "------------------------------------------------------", "-----------", "-----------"));
                        
                        foreach (var item in query)
                        {
                            txt.AppendLine(String.Format("{0,-54} {1,11} {2,11}", item.City, item.CustomerCount, item.OrderCount));
                        }

                        txt.AppendLine(String.Format("{0,-54} {1,11} {2,11}", "------------------------------------------------------", "-----------", "-----------"));
                        Console.Write(txt.ToString());
                    }

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
