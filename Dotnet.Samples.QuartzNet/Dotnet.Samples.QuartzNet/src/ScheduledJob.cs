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

namespace Dotnet.Samples.QuartzNet
{

    #region References
    using System;
    using Quartz;
    using Common.Logging;
    #endregion

    public class ScheduledJob : IJob
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ScheduledJob));

        public ScheduledJob()
        {
        }

        public void Execute(JobExecutionContext context)
        {
            try
            {
                var message = "The quick brown fox jumps over the lazy dog.";

                if (log.IsInfoEnabled)
                {
                    log.Info(message);
                }
                else
                {
                    Console.WriteLine(message);
                }
            }
            catch (JobExecutionException error)
            {
                var message = String.Format("Quartz.NET Job error: {0}", error.Message);

                if (log.IsErrorEnabled)
                {
                    log.Error(message);
                }
                else
                {
                    Console.WriteLine(message);
                }

                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey(true);
            }
        }
    }
}
