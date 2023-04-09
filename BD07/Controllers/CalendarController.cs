using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
//using System.Web.Http;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Google.Apis.Util.Store;

namespace BD07.Controllers
{
    public class CalendarController : Controller
    {
        public List<string> GoogleEvents = new List<string>();
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "MyMed";
        //GET: Home
        public ActionResult Index()
        {
            CalendarEvents();
            ViewBag.Eventlist=GoogleEvents;
            return View(); 
        }

        public void CalendarEvents()
        {
            UserCredential credential;
           
            using (var stream = new FileStream("Credential.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted= false;
            request.SingleEvents= true;
            request.MaxResults = 10;

            Events events = request.Execute();
            Console.WriteLine("Upcoming events: ");
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach(var eventItem in events.Items)
                {
                    GoogleEvents.Add(eventItem.Summary);
                }
            }
        }
    }


}
