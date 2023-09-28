/*
 * Name: James
 * Date: 2021
 * Purpose: Call External Event Class for Object Oriented Programming Assignment
 * CalExtEvent class = CustomerID, EventID, title, description, location, startTime, duration, endtime. Also implement interface ICalEventPrint
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Object_Oriented_Programming_Assignment
{
    public class CalExtEvent : CalEvent
    {
        public int CustomerID { get; set; } //Event ID for Internal Event

        public override void printEvent()
        {
            Console.WriteLine("Customer ID: " + CustomerID);
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
