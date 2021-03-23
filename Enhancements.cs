namespace TicketSystemSearch
{
    public class Enhancements : System
    {
        //properties
        public string software { get; set; }
        public string cost { get; set; }
        public string reason { get; set; }
        public int estimate { get; set; }

        //method
        //display to console
        public override string Display() 
        {
            return $"ID: {ID}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigner: {assigner}\nWatcher: {string.Join(", ", watchers)}\nSoftware: {software}\nCost: {cost}\nReason: {reason}\nEstimate: {estimate}\n";
        }
    }
}