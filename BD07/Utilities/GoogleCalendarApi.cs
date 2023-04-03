
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
    public class GoogleCalendarApi
    {
        public void AddEventToCalendar(string eventSummary, string eventLocation, DateTime startTime, DateTime endTime)
        {
            // Create the CalendarService object
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = GetCredential(),
                ApplicationName = "MyMed"
            });

            // Create the event
            var newEvent = new Event()
            {
                Summary = eventSummary,
                Location = eventLocation,
                Start = new EventDateTime()
                {
                    DateTime = startTime,
                    TimeZone = "Europe/Amsterdam"
                },
                End = new EventDateTime()
                {
                    DateTime = endTime,
                    TimeZone = "Europe/Amsterdam"
                }
            };

            // Add the event to the calendar
            var request = service.Events.Insert(newEvent, "primary");
            request.Execute();
        }

        private UserCredential GetCredential()
        {
            // Path to the credentials file
            string credPath = "Credentials/credentials.json";

            // Scopes for the Google Calendar API
            string[] scopes = { CalendarService.Scope.Calendar };

            // Load the credentials file
            using (var stream = new FileStream(credPath, FileMode.Open, FileAccess.Read))
            {
                // Create the credentials object
                var credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(scopes)
                    .UnderlyingCredential as UserCredential;

                return credential;
            }
        }
    }
}
