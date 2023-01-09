using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzConsole.Jobs
{
    public class GenerateNumberJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"Random value : {RandomNumber(10, 200)}");
            return Task.CompletedTask;
        }


        private int RandomNumber(int min, int max)
        {
            var rand = new Random();
            return rand.Next(min, max);
        }


    }

}
