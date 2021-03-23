using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace TicketSystemSearch
{
    public class TaskFile
    {
        //properties
        public string pathFile { get; set; }
        public List<Tasks> Tasks { get; set; }
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        //constructor
        public TaskFile (string taskFilePath) 
        {
            pathFile = taskFilePath;
            Tasks = new List<Tasks>();

            //populate list with data
            //read from data file
            try {
                StreamReader sr = new StreamReader(pathFile);
                while (!sr.EndOfStream) {
                    string line = sr.ReadLine();
                    //seperate ticket details with commas
                    string[] array = line.Split(',');

                    //instance of tasks class
                    Tasks tasks = new Tasks();

                    //task details
                    tasks.ID = Convert.ToInt32(array[0]);
                    tasks.summary = array[1];
                    tasks.status = array[2];
                    tasks.priority = array[3];
                    tasks.submitter = array[4];
                    tasks.assigner = array[5];
                    tasks.watchers = array[6].Split('|').ToList();
                    tasks.projectName = array[7];
                    tasks.dueDate = array[8];

                    //add task
                    Tasks.Add(tasks);
                }
                sr.Close();
            } catch (Exception ex) {
                logger.Error(ex.Message);
            }
        }

        public void AddTicket(Tasks tasks) 
        {
            try {
                StreamWriter sw = new StreamWriter(pathFile, append: true);
                //display to csv file
                sw.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", tasks.ID, tasks.summary, tasks.status, tasks.priority, tasks.submitter, tasks.assigner, string.Join("|", tasks.watchers), tasks.projectName, tasks.dueDate);
                sw.Close();

                //add task to list
                Tasks.Add(tasks);

            } catch (Exception ex) {
                logger.Error(ex.Message);
            }
        }
    }
}