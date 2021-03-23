using System;
using NLog.Web;
using System.IO;
using System.Linq;

namespace TicketSystemSearch
{
    class Program
    {
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
            string ticketFilePath = Directory.GetCurrentDirectory() + "\\Tickets.csv";
            TicketFile ticketFile = new TicketFile(ticketFilePath);

            string enhancementFilePath = Directory.GetCurrentDirectory() + "\\Enhancements.csv";
            EnhancementFile enhancementFile = new EnhancementFile(enhancementFilePath);

            string taskFilePath = Directory.GetCurrentDirectory() + "\\Tasks.csv";
            TaskFile taskFile = new TaskFile(taskFilePath);

            logger.Info("Program started");

            string userChoice;
            do {
                Console.WriteLine("1.) Display all tickets\n2.) Create a ticket\n3.) Exit\n");
                userChoice = Console.ReadLine();

                if (userChoice == "1") {
                    foreach (System s in ticketFile.Systems) {
                        Console.WriteLine(s.Display());
                    }
                    foreach (Enhancements e in enhancementFile.Enhancements) {
                        Console.WriteLine(e.Display());
                    }
                    foreach (Tasks t in taskFile.Tasks) {
                        Console.WriteLine(t.Display());
                    }
                } else if (userChoice == "2") {
                    Console.WriteLine("Create a ticket");

                    string userOption;
                    do {
                        Console.WriteLine("What type of ticket are you creating?");
                        Console.WriteLine("1.) Bug/Defect\n2.) Enhancement\n3.) Task\n4.) Exit");
                        userOption = Console.ReadLine();

                        if (userOption == "1") {
                            //add ticket
                            Tickets tickets = new Tickets();

                            //ask user 
                            Console.WriteLine("Bug/Defect");
                            Console.WriteLine("Enter the following");

                            Console.WriteLine("ID:");
                            tickets.ID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Summary:");
                            tickets.summary = Console.ReadLine();

                            Console.WriteLine("Status:");
                            tickets.status = Console.ReadLine();

                            Console.WriteLine("Priority:");
                            tickets.priority = Console.ReadLine();

                            Console.WriteLine("Submitter:");
                            tickets.submitter = Console.ReadLine();

                            Console.WriteLine("Assigner:");
                            tickets.assigner = Console.ReadLine();

                            string watchers;
                            do {
                                Console.WriteLine("Watchers (Enter 'done' when fininshed)");
                                watchers = Console.ReadLine();

                                if (watchers != "done" && watchers.Length > 0) {
                                    tickets.watchers.Add(watchers);
                                } else if (tickets.watchers.Count == 0) {
                                    tickets.watchers.Add("(No watchers listed)");
                                }

                            } while (watchers != "done");

                            Console.WriteLine("Severity:");
                            tickets.severity = Console.ReadLine();

                            //add ticket
                            ticketFile.AddTicket(tickets);
                        } else if (userOption == "2") {
                            Enhancements enhancements = new Enhancements();

                            Console.WriteLine("Enhancement");
                            Console.WriteLine("Enter The Following");

                            Console.WriteLine("ID:");
                            enhancements.ID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Summary:");
                            enhancements.summary = Console.ReadLine();

                            Console.WriteLine("Status:");
                            enhancements.status = Console.ReadLine();

                            Console.WriteLine("Priority:");
                            enhancements.priority = Console.ReadLine();

                            Console.WriteLine("Submitter:");
                            enhancements.submitter = Console.ReadLine();

                            Console.WriteLine("Assigner:");
                            enhancements.assigner = Console.ReadLine();

                            string watchers;
                            do {
                                Console.WriteLine("Watchers (Enter 'done' when fininshed)");
                                watchers = Console.ReadLine();

                                if (watchers != "done" && watchers.Length > 0) {
                                    enhancements.watchers.Add(watchers);
                                } else if (enhancements.watchers.Count == 0) {
                                    enhancements.watchers.Add("(No watchers listed)");
                                }

                            } while (watchers != "done");

                            Console.WriteLine("Software:");
                            enhancements.software = Console.ReadLine();

                            Console.WriteLine("Cost:");
                            enhancements.cost = Console.ReadLine();

                            Console.WriteLine("Reason:");
                            enhancements.reason = Console.ReadLine();

                            Console.WriteLine("Estimate:");
                            enhancements.estimate = Convert.ToInt32(Console.ReadLine());

                            enhancementFile.AddTicket(enhancements);
                        } else if (userOption == "3") {
                            Tasks tasks = new Tasks();

                            Console.WriteLine("Task");
                            Console.WriteLine("Enter the following");

                            Console.WriteLine("ID:");
                            tasks.ID = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Summary:");
                            tasks.summary = Console.ReadLine();

                            Console.WriteLine("Status:");
                            tasks.status = Console.ReadLine();

                            Console.WriteLine("Priority:");
                            tasks.priority = Console.ReadLine();

                            Console.WriteLine("Submitter:");
                            tasks.submitter = Console.ReadLine();

                            Console.WriteLine("Assigner:");
                            tasks.assigner = Console.ReadLine();

                            string watchers;
                            do {
                                Console.WriteLine("Watchers (Enter 'done' when fininshed)");
                                watchers = Console.ReadLine();

                                if (watchers != "done" && watchers.Length > 0) {
                                    tasks.watchers.Add(watchers);
                                } else if (tasks.watchers.Count == 0) {
                                    tasks.watchers.Add("(No watchers listed)");
                                }

                            } while (watchers != "done");

                            Console.WriteLine("Project Name:");
                            tasks.projectName = Console.ReadLine();

                            Console.WriteLine("Due Date:");
                            tasks.dueDate = Console.ReadLine();

                            taskFile.AddTicket(tasks);
                        }
                    } while (userOption == "1" || userOption == "2" || userOption == "3");
                } 
          } while (userChoice == "1" || userChoice == "2");

            logger.Info("Program ended");
        }
    }
}
