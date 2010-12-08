using System;
using Quartz;
using Quartz.Impl;
using System.Text;
using Common.Logging;

namespace Dotnet.Samples.QuartzNet
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            try
            {

                if (log.IsDebugEnabled) log.Debug("Apache log4net successfully initialized.");

                InitializeScheduler();
                InitializeConsole();
            }
            catch (SchedulerException error)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Scheduler error: " + error.Message);
                }
                else
                {
                    Console.WriteLine("[CONSOLE] Quartz.NET Scheduler error: " + error.Message);
                }

                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey(true);
            }
        }

        private static void InitializeScheduler()
        {
            ISchedulerFactory sf = new StdSchedulerFactory();
            IScheduler s = sf.GetScheduler();
            s.Start();
            JobDetail jd = new JobDetail("SampleJob", "SampleJobGroup", typeof(ScheduledJob));
            CronTrigger ct = new CronTrigger("SampleTrigger", "SampleTriggerGroup", "0/4 * * * * ? *");
            s.ScheduleJob(jd, ct);
        }

        private static void InitializeConsole()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Environment.NewLine);
            sb.AppendLine("Sample of Quartz.NET scheduled job");
            sb.AppendLine("----------------------------------");
            sb.AppendLine("Trigger will fire every 4 seconds:");
            sb.AppendLine("(" + "CronExpression = 0/4 * * * * ? *" + ")");

            if (log.IsInfoEnabled)
            {
                log.Info(sb.ToString());
            }
            else
            {
                Console.WriteLine("[CONSOLE] " + sb.ToString());
            }
        }
    }
}
