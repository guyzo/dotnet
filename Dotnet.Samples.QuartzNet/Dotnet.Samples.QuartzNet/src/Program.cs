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
    using System.Text;
    using Common.Logging;
    using Quartz;
    using Quartz.Impl;
    #endregion

    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main()
        {
            try
            {
                if (log.IsDebugEnabled)
                {
                    log.Debug("Apache log4net successfully initialized.");
                }

                InitializeScheduler();
                InitializeConsole();
            }
            catch (SchedulerException error)
            {
                var message = String.Format("Quartz.NET Scheduler error: {0}", error.Message);

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

        private static void InitializeScheduler()
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = schedulerFactory.GetScheduler();
            scheduler.Start();
            JobDetail jobDetail = new JobDetail("SampleJob", "SampleJobGroup", typeof(ScheduledJob));
            CronTrigger cronTrigger = new CronTrigger("SampleTrigger", "SampleTriggerGroup", "0/4 * * * * ? *");
            scheduler.ScheduleJob(jobDetail, cronTrigger);
        }

        private static void InitializeConsole()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(Environment.NewLine);
            stringBuilder.AppendLine("Sample of Quartz.NET scheduled job");
            stringBuilder.AppendLine("----------------------------------");
            stringBuilder.AppendLine("Trigger will fire every 4 seconds:");
            stringBuilder.AppendLine("[CronExpression = 0/4 * * * * ? *]");

            if (log.IsInfoEnabled)
            {
                log.Info(stringBuilder.ToString());
            }
            else
            {
                Console.WriteLine(stringBuilder.ToString());
            }
        }
    }
}
