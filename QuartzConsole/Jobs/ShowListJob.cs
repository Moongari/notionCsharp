using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzConsole.Jobs
{
    public class ShowListJob : IJob
    {
        private readonly List<string> _listPersonne;

        public ShowListJob()
        {
            _listPersonne = new List<string>() { "Albert", "Robert", "Eric", "Tatiana" };
           
        }


        public Task Execute(IJobExecutionContext context)
        {
            IEnumerable<string> list = _listPersonne.ToList();
            foreach (var item in list)
            {
                Console.WriteLine($"Name : {item}");
            }
            return Task.CompletedTask;
        }
    }
}
