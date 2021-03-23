namespace TicketSystemSearch
{
    public class Tasks : System
    {
        //properties
        public string projectName { get; set; }
        public string dueDate { get; set; }


        //method
        //display to console
        public override string Display() 
        {
            return $"ID: {ID}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigner: {assigner}\nWatcher: {string.Join(", ", watchers)}\nProject Name: {projectName}\nDue Date:{dueDate}\n";
        }
    }
}