using System;
using Quartz;
using Common.Logging;

namespace Dotnet.Samples.QuartzNet
{
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
                if (log.IsInfoEnabled)
                {
                    log.Info("The quick brown fox jumps over the lazy dog.");
                }
                else
                {
                    Console.WriteLine("[CONSOLE] " + "The quick brown fox jumps over the lazy dog.");
                }
            }
            catch (JobExecutionException error)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Job error: " + error.Message);
                }
                else
                {
                    Console.WriteLine("[CONSOLE] Quartz.NET Job error: " + error.Message);
                }

                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey(true);
            }
        }
    }
}
