
using BD07.Models;
using BD07.Services.pub;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BD07.Utilities
{
    public class GoogleCalendarApi: IGoogleCalendarApi
    {
        private readonly CalendarService _calendarService;

        public GoogleCalendarApi() {
        
        }
        
        public void AddEventToCalendar(string eventSummary, string eventLocation, Persciption prescription)
        {
            // Create the CalendarService object
            _calendarService = new CalendarService(new BaseClientService.Initializer()
            {
            //    HttpClientInitializer = GetCredential(),
                ApplicationName = "MyMed"
            });
        }

        public void AddEventToCalendar(string eventSummary, string eventLocation, Persciption prescription)
        {
            // Set the start and end time of the event
            var eventStartTime = prescription.Schedule;
            var eventEndTime = prescription.Schedule.AddMinutes(15);

            // Create the event
            var newEvent = new Event()
            {
                Summary = eventSummary,
                Location = eventLocation,
                Start = new EventDateTime()
                {
                    DateTime = eventStartTime,
                    TimeZone = "Europe/Amsterdam"
                },
                End = new EventDateTime()
                {
                    DateTime = eventEndTime,
                    TimeZone = "Europe/Amsterdam"
                }
            };

            // Add the event to the calendar
            var request = _calendarService.Events.Insert(newEvent, "primary");
            request.Execute();
        }

        //   private UserCredential GetCredential()
        // {
        // Path to the credentials file
        //     string credPath = "Credentials/credentials.json";

        // Scopes for the Google Calendar API
        //    string[] scopes = { CalendarService.Scope.Calendar };

        // Load the credentials file
        // using (var stream = new FileStream(credPath, FileMode.Open, FileAccess.Read))
        //   {
        //  // Create the credentials object
        //  var credential = GoogleCredential.FromStream(stream)
        //      .CreateScoped(scopes)
        //    .UnderlyingCredential as UserCredential;

        //   return credential;
        //  }
    }
  //  }
}
