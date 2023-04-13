using BD07.Models;

namespace BD07.Services.pub
{
    public interface IGoogleCalendarApi
    {
        public void AddEventToCalendar(string eventSummary, string eventLocation, Prescription prescription);
    }
}
