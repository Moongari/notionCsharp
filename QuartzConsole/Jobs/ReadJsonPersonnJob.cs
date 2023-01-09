using Newtonsoft.Json;
using Quartz;
using QuartzConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzConsole.Jobs
{
    public class ReadJsonPersonnJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {


            //Console.WriteLine($" Id : {ReadJsonPersonnFile().Id} , Name : {ReadJsonPersonnFile().Name}, LastName : {ReadJsonPersonnFile().LastName} ,Age : {ReadJsonPersonnFile().Age}");

            ReadJsonPersonnFile();
            
            return Task.CompletedTask;  
        }


        //add Newtonsoft.Json in by package nuget
        private void  ReadJsonPersonnFile()
        {
   
        
            try
            {
                string? json = File.ReadAllText("personn.json");
                List<Personn> ListOfpersonns = JsonConvert.DeserializeObject<List<Personn>>(json);

                foreach (var item in ListOfpersonns)
                {
                    Console.WriteLine($"id{item.Id}, {item.Age}");
                }
              
            }
            catch (JsonSerializationException ex )
            {

                Console.WriteLine ("probleme rencontré :"+ ex.Message);
            }
            catch(FileNotFoundException ex )
            {
                Console.WriteLine($"file not found  {ex.Message}");
            }
            

           
           
        }












    }

}
