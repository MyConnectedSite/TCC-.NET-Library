using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCC2.API;
using System.Threading;

namespace FileNotification
{
    class Program
    {
        static void Main(string[] args)
        {
            Session session = new Session("https://nitrogen.myconnectedsite.com/tcc");

            session.Open("yourid", "youorg", "yourpassword");
            DeleteOldEvents(session);
            try
            {
                for (; ; )
                {
                    Console.WriteLine("Looking for events...");
                    GetEvents getEvents = new GetEvents(session);
                    GetEventsResult result = getEvents.Call("null", 500);
                    if (result.Events.Count == 0)
                    {
                        Console.WriteLine("No events found. Sleeping...");
                        Thread.Sleep(60000);
                        continue;
                    }


                    foreach (Event evt in result.Events)
                    {
                        Console.WriteLine("Processing tag file " + evt.FilespaceId + ":" + evt.FilePath);
                        //...file download, processing, etc... goes here 
                        SetEvents setEvents = new SetEvents(session);
                        setEvents.Call(evt.EventId, "complete", "VSS Tag File Scanner");
                    }
                }
            }
            finally
            {
                session.Close();
            }




        }

        //this method deletes any completed events over 90 days old
        //this is done so that the internal queue table stays a reasonable size
        public static void DeleteOldEvents(Session session)
        {
            Console.WriteLine("Looking for old events...");
            GetEvents getEvents = new GetEvents(session);
           
            GetEventsResult result = getEvents.Call("complete", 500, DateTime.UtcNow.AddDays(90));
            if (result.Events.Count == 0)
            {
                Console.WriteLine("None found.");
                return;
            }

            LinkedList<string> eventsToDelete = new LinkedList<string>();
            foreach (Event evt in result.Events)
            {
                eventsToDelete.AddLast(evt.EventId);
                if (eventsToDelete.Count >= 500)
                {
                    Console.WriteLine("Deleting " + eventsToDelete.Count +" old events.");
                    DeleteEvents deleteEvents = new DeleteEvents(session);
                    deleteEvents.Call(eventsToDelete);
                    eventsToDelete.Clear();  
                }              
            }

            if (eventsToDelete.Count > 0)
            {
                Console.WriteLine("Deleting " + eventsToDelete.Count + " old events.");
                DeleteEvents deleteEvents = new DeleteEvents(session);
                deleteEvents.Call(eventsToDelete);
            }
        }
    }
}
