namespace SSH_FrontEnd.VM.Admin
{
    public class AdminDashboardViewModel
    {
        public int TotalUsers { get; set; }
        public int TotalEvents { get; set; }
        public List<AdminEventStatsViewModel> EventStats { get; set; }
    }

    public class AdminEventStatsViewModel
    {
        public string EventType { get; set; }
        public int Count { get; set; }
    }
}
