/*
 * Name: James
 * Date: 2021
 * Purpose: Call Internal Event Class for Object Oriented Programming Assignment
 * CalIntEvent class = RoomNumber, EventID, title, description, location, startTime, duration, endtime. Also implement interface ICalEventPrint
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Object_Oriented_Programming_Assignment
{
    public class CalIntEvent : CalEvent
    {
        public int RoomNumber { get; set; } //Event ID for Internal Event

        public override void printEvent()
        {
            Console.WriteLine("Room Number: " + RoomNumber);
            Console.WriteLine("==========================");
            base.printEvent(); //Contains printEvent interface contents
            Console.WriteLine("\n");
        }
        public override void saveEvent()
        {
            base.saveEvent();
        }
    }
}
