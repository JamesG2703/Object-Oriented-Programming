/*
 * Name: James
 * Date: 2021
 * Purpose: Call Event Class for Object Oriented Programming Assignment
 * CalEvent class = EventID, title, description, location, startTime, duration, endtime. Also implement interface ICalEventPrint
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Object_Oriented_Programming_Assignment
{
    public abstract class CalEvent: IEventPrint, IEventSave, IEventUpdate, IEventDelete //Combines Interface with main class
    {
        [Key]
        public int EventID { get; set; } //Primary Key
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }

        //public virtual ICollection<CalEvent> CalExtEvent { get; set; } // Use ICollection here
        //public virtual ICollection<CalEvent> CalIntEvent { get; set; }

        public virtual void printEvent() //Print All Events in Date Order
        {
            DateTime EndDate = StartTime + Duration; //Creates an end time for the end of duration

            Console.WriteLine("EventID: " + EventID + "\n\nTitle: " + Title + "\n\nDescription: " + Description + "\n\nLocation: " 
                + Location + "\n\nStartTime: " + StartTime + "\n\nDuration: " + Duration + "\n\nEndTime: " + EndDate);
        }

        //public virtual void internalprintEvent() //Print Internal Events
        //{
        //    Console.WriteLine("EventID: " + EventID  + "\n\nTitle: " + Title + "\n\nDescription: " 
        //        + Description + "\n\nLocation: " + Location + "\n\nStartTime: " + StartTime);
        //}

        //public virtual void externalprintEvent() //Print External Events
        //{
        //    Console.WriteLine("EventID: " + EventID + "\n\nTitle: " + Title + "\n\nDescription: " 
        //        + Description + "\n\nLocation: " + Location + "\n\nDuration: " + Duration);
        //}

        public virtual void saveEvent() //Save Event Interface
        {
            Console.WriteLine("Saving...");
        }

        public virtual void updateEvent() //Update Event Interface
        {
            Console.WriteLine("Updating...");
        }

        public virtual void deleteEvent() //Delete Event Interface
        {
            Console.WriteLine("Deleting...");
        }
    }
}
