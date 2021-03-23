namespace TicketSystemSearch
{
    //ticket class derived from system class
    public class Tickets : System
    {
        //property
        public string severity { get; set; }

        //method
        //displays to console
        public override string Display()
        {
            return $"ID: {ID}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigner: {assigner}\nWatcher: {string.Join(", ", watchers)}\nSeverity: {severity}\n";
        }
    }
}