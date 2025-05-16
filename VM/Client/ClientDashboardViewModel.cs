using SSH_FrontEnd.VM.EventVM;

namespace SSH_FrontEnd.VM.Client
{
    public class ClientDashboardViewModel
    {
        public string WelcomeMessage { get; set; }
        public IEnumerable<MyEventsViewModel> UpcomingEvents { get; set; }
    }
}
