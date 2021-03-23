using System.Collections.Generic;

namespace TicketSystemSearch
{
    public abstract class System
    {
        //public properties
        public int ID { get; set; }
        public string summary { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
        public string submitter { get; set; }
        public string assigner { get; set; }
        public List<string> watchers { get; set; }
        
        //constructor
        public System() 
        {
            watchers = new List<string>();
        }

        //public method
        //displays to console
        public virtual string Display()
        {
            return $"ID: {ID}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigner: {assigner}\nWatcher: {string.Join(", ", watchers)}\n";
        }
    }
}