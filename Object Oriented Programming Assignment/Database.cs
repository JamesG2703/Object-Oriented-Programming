/*
 * Name: James
 * Date: 2021
 * Purpose: Call Internal Event Class for Object Oriented Programming Assignment
 * CalIntEvent class = RoomNumber, EventID, title, description, location, startTime, duration, endtime. Also implement interface ICalEventPrint
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Object_Oriented_Programming_Assignment
{
    class Database : DbContext
    {
        public DbSet<CalEvent> Events { get; set; } //Event list
        /*public DbSet<CalExtEvent> ExtEvents { get; set; }*/ //External Event list
        /*public DbSet<CalIntEvent> IntEvents { get; set; }*/ //Internal Event list
    }
}
