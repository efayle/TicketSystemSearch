using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace TicketSystemSearch
{
    public class EnhancementFile
    {
        //properties
        public string path { get; set; }
        public List<Enhancements> Enhancements { get; set; }
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        //constructor
        public EnhancementFile (string enhancementFilePath) 
        {
            path = enhancementFilePath;
            Enhancements = new List<Enhancements>();


            //populate list with data
            //read from data file
            try {

                StreamReader sr = new StreamReader(path);
                while (!sr.EndOfStream) {
                    string line = sr.ReadLine();
                     //seperate ticket details with commas
                    string[] array = line.Split(',');

                    //instance of enhancements class
                    Enhancements enhancements = new Enhancements();

                    //enhancement details
                    enhancements.ID = Convert.ToInt32(array[0]);
                    enhancements.summary = array[1];
                    enhancements.status = array[2];
                    enhancements.priority = array[3];
                    enhancements.submitter = array[4];
                    enhancements.assigner = array[5];
                    enhancements.watchers = array[6].Split('|').ToList();
                    enhancements.software = array[7];
                    enhancements.cost = array[8];
                    enhancements.reason = array[9];
                    enhancements.estimate = Convert.ToInt32(array[10]);

                    //add enhancement
                    Enhancements.Add(enhancements);

                }
                sr.Close();

            } catch (Exception ex) {
                logger.Error(ex.Message);
            }
        }

        //public method
        public void AddTicket(Enhancements enhancements)
        {
            try {
                StreamWriter sw = new StreamWriter(path, append: true);
                //display to csv file
                sw.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", enhancements.ID, enhancements.summary, enhancements.status, enhancements.priority, enhancements.submitter, enhancements.assigner, string.Join("|", enhancements.watchers), enhancements.software, enhancements.cost, enhancements.reason, enhancements.estimate);
                sw.Close();

                //add enhancement to list
                Enhancements.Add(enhancements);

            } catch (Exception ex) {
                logger.Error(ex.Message);
            }
        }
    }
}