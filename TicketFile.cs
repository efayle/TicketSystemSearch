using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace TicketSystemSearch
{
    public class TicketFile
    {
        //properties
        public string filePath { get; set; }
        public List<System> Systems { get; set; }

        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        //constructor
        public TicketFile (string ticketFilePath) 
        {
            filePath = ticketFilePath;
            Systems = new List<System>();

            //populate list with data
            //read from data file
            try {
                StreamReader sr = new StreamReader(filePath);
                while (!sr.EndOfStream) {
                    string line = sr.ReadLine();
                    //seperate ticket details with commas
                    string[] array = line.Split(',');

                    //instance of tickets class
                    Tickets tickets = new Tickets();

                    //ticket details
                    tickets.ID = Convert.ToInt32(array[0]);
                    tickets.summary = array[1];
                    tickets.status = array[2];
                    tickets.priority = array[3];
                    tickets.submitter = array[4];
                    tickets.assigner = array[5];
                    tickets.watchers = array[6].Split('|').ToList();
                    tickets.severity = array[7];

                    //add ticket
                    Systems.Add(tickets);
                }
                sr.Close();
            } catch (Exception ex) {
                logger.Error(ex.Message);
            }
        }

        //public method
        public void AddTicket(Tickets tickets)
        {
            try {
                StreamWriter sw = new StreamWriter(filePath, append: true);
                //displays to csv file
                sw.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}", tickets.ID, tickets.summary, tickets.status, tickets.priority, tickets.submitter, tickets.assigner, string.Join("|", tickets.watchers), tickets.severity);
                sw.Close();

                //add ticket to list
                Systems.Add(tickets);
            } catch (Exception ex) {
                logger.Error(ex.Message);
            }
        }
    }
}