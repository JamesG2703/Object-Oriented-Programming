/*
 * Name: James
 * Date: 2021
 * Purpose: Object Oriented Programming Assignment Main program
 */
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Globalization;
using System.Data.Entity.Infrastructure;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Figgle;
using Nest;

namespace Object_Oriented_Programming_Assignment
{
    public class Program: CalEvent
    {
        public static void Main(string[] args)
        {
            //Console Customization
            Console.Title = "Object-Oriented Programming Assignment";
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.WriteLine(FiggleFonts.FiveLineOblique.Render("James's App"));

            var db = new Database(); //Accesses Database
            int option; //Integer used for selecting menu option

            //Menu creation
            string menu = "Welcome to the Main Menu of the Calander!\n";
            menu += "1) See all events in date order\n";
            menu += "2) Create an Event\n";
            menu += "3) See all Internal Events\n";
            menu += "4) See all External Events\n";
            menu += "5) Update an Event\n";
            menu += "6) Delete an Event\n";
            menu += "7) Exit\n";

            using (db) //Uses Database
            {
                do
                {
                    Console.WriteLine(menu); //Prints menu
                    option = Convert.ToInt16(Console.ReadLine());

                    switch (option)
                    {
                        //Prints all events
                        case 1:
                            var count = db.Events.Count();
                            if (count > 0)
                            {
                                var all = from b in db.Events orderby b.Title select b;
                                Console.WriteLine("\nAll Events\n");

                                foreach (var item in all)
                                {
                                    item.printEvent();
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nNo Events\n");
                            }
                            break;

                        case 2:
                            //Creates a new event
                            string addEvent = "yes";
                            do
                            {
                                Console.WriteLine("\nCreate an Event\n");
                                Console.WriteLine("\nInternal(1) or External(2)?\n");
                                Console.WriteLine("\nQuit(3)\n");
                                int e = Convert.ToInt16(Console.ReadLine());
                                if (e == 1)
                                {
                                    //Creates a new internal event
                                    Console.WriteLine("What is the EventID?");
                                    int eventid = Convert.ToInt16(Console.ReadLine());
                                    Console.WriteLine("What is the Room Number?");
                                    int roomnum = Convert.ToInt16(Console.ReadLine());
                                    Console.WriteLine("What is the Event Title?");
                                    string title = Console.ReadLine();
                                    Console.WriteLine("What is the Event Description?");
                                    string description = Console.ReadLine();
                                    Console.WriteLine("What is the Location?");
                                    string location = Console.ReadLine();
                                    Console.WriteLine("Start Time 'dd/MM/yyyy HH:mm' : ");
                                    string format = "dd/MM/yyyy HH:mm";
                                    DateTime startTime = DateTime.ParseExact(Console.ReadLine(), format, null);

                                    Console.WriteLine("\nEvent Duration:");
                                    Console.WriteLine("Hour:");
                                    int hours = Convert.ToInt16(Console.ReadLine());
                                    Console.WriteLine("Minutes:");
                                    int minutes = Convert.ToInt16(Console.ReadLine());

                                    TimeSpan duration = new TimeSpan(hours, minutes, 0);

                                    //Places inputs into values
                                    CalEvent newintevent = new CalIntEvent
                                    {
                                        Title = title,
                                        EventID = eventid,
                                        RoomNumber = roomnum,
                                        Description = description,
                                        Location = location,
                                        StartTime = startTime,
                                        Duration = duration
                                    };

                                    newintevent.Title = title;
                                    db.Events.Add(newintevent); //Adds to internal event list
                                    try
                                    {
                                        //Saves to database
                                        db.SaveChanges();
                                        //Prints IEventSave interface
                                        newintevent.saveEvent();
                                    }
                                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                                    {
                                        //Exception if inputs could not be implemented into database
                                        Console.WriteLine("\nError, could not create Internal Event!");
                                    }
                                }
                                else if (e == 2)
                                {
                                    //Creates new external event
                                    Console.WriteLine("What is the EventID?");
                                    int eventid = Convert.ToInt16(Console.ReadLine());
                                    Console.WriteLine("What is the Customer ID?");
                                    int custid = Convert.ToInt16(Console.ReadLine());
                                    Console.WriteLine("What is the Event Title?");
                                    string title = Console.ReadLine();
                                    Console.WriteLine("What is the Event Description?");
                                    string description = Console.ReadLine();
                                    Console.WriteLine("What is the Location?");
                                    string location = Console.ReadLine();
                                    try
                                    {
                                        Console.WriteLine("\nStart Date:");
                                        Console.WriteLine("Day:");
                                        int day = Convert.ToInt16(Console.ReadLine());
                                        Console.WriteLine("Month:");
                                        int month = Convert.ToInt16(Console.ReadLine());
                                        Console.WriteLine("Year:");
                                        int year = Convert.ToInt16(Console.ReadLine());
                                        Console.WriteLine("\nStart Time: (24H)");
                                        Console.WriteLine("Hour:");
                                        int hour = Convert.ToInt16(Console.ReadLine());
                                        Console.WriteLine("Minute:");
                                        int minute = Convert.ToInt16(Console.ReadLine());

                                        DateTime startTime = new DateTime(year, month, day, hour, minute, 0);

                                        Console.WriteLine("\nEvent Duration:");
                                        Console.WriteLine("Hour:");
                                        int hours = Convert.ToInt16(Console.ReadLine());
                                        Console.WriteLine("Minutes:");
                                        int minutes = Convert.ToInt16(Console.ReadLine());

                                        TimeSpan duration = new TimeSpan(hours, minutes, 0);

                                        CalEvent newextevent = new CalExtEvent
                                        {
                                            Title = title,
                                            EventID = eventid,
                                            CustomerID = custid,
                                            Description = description,
                                            Location = location,
                                            StartTime = startTime,
                                            Duration = duration
                                        };

                                        newextevent.Title = title;
                                        db.Events.Add(newextevent);
                                        try
                                        {
                                            db.SaveChanges();
                                            newextevent.saveEvent();
                                        }
                                        catch (Exception)
                                        {

                                            throw;
                                        }
                                    }
                                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                                    {
                                        Console.WriteLine("\nError, could not create External Event!\n");
                                    }
                                    addEvent = Console.ReadLine();
                                }
                                else if (e == 3)
                                {
                                    //This option returns to the main menu
                                    break;
                                }
                            } while (addEvent == "yes");
                            break;

                        case 3:
                            //Prints all internal events
                            var intcount = db.Events.Count();
                            if (intcount > 0)
                            {
                                Console.WriteLine("Internal Events\n");
                                foreach (var item in db.Events)
                                {
                                    Type t = item.GetType();
                                    //Gets Internal Event list
                                    if (t.Equals(typeof(CalIntEvent)))
                                        item.printEvent();
                                }
                            }
                            else
                            {
                                //Executes when there are no internal events stored
                                Console.WriteLine("\nNo Events\n");
                            }
                            break;

                        case 4:
                            //Prints all external events
                            var extcount = db.Events.Count();
                            if (extcount > 0)
                            {
                                Console.WriteLine("External Events\n");
                                foreach (var item in db.Events)
                                {
                                    Type t = item.GetType();
                                    if (t.Equals(typeof(CalExtEvent)))
                                        item.printEvent();
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nNo Events\n");
                            }
                            break;

                        case 5:
                            //Updates Events
                            var upcount = db.Events.Count();
                            if (upcount > 0)
                            {
                                Console.WriteLine("\nAll Updateable Events!\n");
                                var queryall = from b in db.Events orderby b.Title select b;

                                foreach (var item in queryall)
                                {
                                    item.printEvent();
                                }
                                Console.WriteLine("Internal(1) or External(2)");
                                Console.WriteLine("\nQuit(3)\n");
                                int e = Convert.ToInt16(Console.ReadLine());
                                if (e == 1)
                                {
                                    //Updates Internal Events
                                    Console.WriteLine("\nWhat EventID would you like to update\n\nEventID:");
                                    var upid = Convert.ToInt16(Console.ReadLine());
                                    var intEvent = from b in db.Events.OfType<CalIntEvent>()
                                                   where (b.EventID == upid)
                                                   select b;
                                    Console.WriteLine("\nEventID-{0}-Selected\n", upid);
                                    Console.WriteLine("Update Room Number:\n");
                                    try
                                    {
                                        var newroomno = Convert.ToInt16(Console.ReadLine());

                                        foreach (var item in intEvent)
                                        {
                                            //Stores new input into value and replaces the old one
                                            item.RoomNumber = newroomno;
                                            //Prints IEventUpdate Interface
                                            item.updateEvent();
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("\nIncorrect Format Try Again!\n");
                                        Console.WriteLine("===============================");
                                        break;
                                    }

                                    Console.WriteLine("Update Title:\n");
                                    var newtitle = Console.ReadLine();

                                    foreach (var item in intEvent)
                                    {
                                        item.Title = newtitle;
                                        item.updateEvent();
                                    }

                                    Console.WriteLine("Update Description:\n");
                                    var newdescription = Console.ReadLine();

                                    foreach (var item in intEvent)
                                    {
                                        item.Description = newdescription;
                                        item.updateEvent();
                                    }

                                    Console.WriteLine("Update Location:\n");
                                    var newlocation = Console.ReadLine();

                                    foreach (var item in intEvent)
                                    {
                                        item.Location = newlocation;
                                        item.updateEvent();
                                    }

                                    try
                                    {
                                        Console.WriteLine("Update Start Time 'dd/MM/yyyy HH:mm':\n");
                                        string format = "dd/MM/yyyy HH:mm";
                                        DateTime newstartTime = DateTime.ParseExact(Console.ReadLine(), format, null);
                                        foreach (var item in intEvent)
                                        {
                                            item.StartTime = newstartTime;
                                            item.updateEvent();
                                        }

                                        Console.WriteLine("Update Event Duration:\n");
                                        Console.WriteLine("Hour:");
                                        int hours = Convert.ToInt16(Console.ReadLine());
                                        Console.WriteLine("Minutes:");
                                        int minutes = Convert.ToInt16(Console.ReadLine());

                                        TimeSpan newduration = new TimeSpan(hours, minutes, 0);
                                        foreach (var item in intEvent)
                                        {
                                            item.Duration = newduration;
                                            item.updateEvent();
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("\nIncorrect Format Try Again!\n");
                                        Console.WriteLine("===============================");
                                        break;
                                    }
                                    try
                                    {
                                        //Saves to database
                                        db.SaveChanges();
                                    }
                                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                                    {
                                        //Error when could not update database
                                        Console.WriteLine("Error, could not update internal event!");
                                    }
                                }
                                else if (e == 2)
                                {
                                    //Updates External Events
                                    Console.WriteLine("\nWhat EventID would you like to update\n\nEventID:");
                                    var upid = Convert.ToInt16(Console.ReadLine());
                                    var extEvent = from b in db.Events.OfType<CalExtEvent>()
                                                   where (b.EventID == upid)
                                                   select b;
                                    Console.WriteLine("\nEventID-{0}-Selected\n", upid);
                                    Console.WriteLine("Update CustomerID:\n");
                                    try
                                    {
                                        var newcustid = Convert.ToInt16(Console.ReadLine());

                                        foreach (var item in extEvent)
                                        {
                                            item.CustomerID = newcustid;
                                            item.updateEvent();
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("\nIncorrect Format Try Again!\n");
                                        Console.WriteLine("===============================");
                                        break;
                                    }

                                    Console.WriteLine("Update Title:\n");
                                    var newtitle = Console.ReadLine();

                                    foreach (var item in extEvent)
                                    {
                                        item.Title = newtitle;
                                        item.updateEvent();
                                    }

                                    Console.WriteLine("Update Description:\n");
                                    var newdescription = Console.ReadLine();

                                    foreach (var item in extEvent)
                                    {
                                        item.Description = newdescription;
                                        item.updateEvent();
                                    }

                                    Console.WriteLine("Update Location:\n");
                                    var newlocation = Console.ReadLine();

                                    foreach (var item in extEvent)
                                    {
                                        item.Location = newlocation;
                                        item.updateEvent();
                                    }
                                    Console.WriteLine("What is the new Start Time?");
                                    Console.WriteLine("\nStart Date:");
                                    Console.WriteLine("Day:");
                                    try
                                    {
                                        int day = Convert.ToInt16(Console.ReadLine());
                                        Console.WriteLine("Month:");
                                        int month = Convert.ToInt16(Console.ReadLine());
                                        Console.WriteLine("Year:");
                                        int year = Convert.ToInt16(Console.ReadLine());
                                        Console.WriteLine("\nStart Time:(24H)");
                                        Console.WriteLine("Hour:");
                                        int hour = Convert.ToInt16(Console.ReadLine());
                                        Console.WriteLine("Minute:");
                                        int minute = Convert.ToInt16(Console.ReadLine());


                                        DateTime newdate = new DateTime(year, month, day, hour, minute, 0);
                                        foreach (var item in extEvent)
                                        {
                                            item.StartTime = newdate;
                                            item.updateEvent();
                                        }

                                        Console.WriteLine("\nEvent Duration:");
                                        Console.WriteLine("Hour:");
                                        int hours = Convert.ToInt16(Console.ReadLine());
                                        Console.WriteLine("Minutes:");
                                        int minutes = Convert.ToInt16(Console.ReadLine());
                                        TimeSpan newduration = new TimeSpan(hours, minutes, 0);
                                        foreach (var item in extEvent)
                                        {
                                            item.Duration = newduration;
                                            item.updateEvent();
                                        }
                                    }
                                    catch(FormatException)
                                    {
                                        Console.WriteLine("\nIncorrect Format Try Again!\n");
                                        Console.WriteLine("===============================");
                                        break;
                                    }
                                    try
                                    {
                                        db.SaveChanges();
                                    }
                                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                                    {
                                        Console.WriteLine("Error, could not update external event!");
                                    }
                                }
                                else if (e == 3)
                                {
                                    //Exits back to main menu
                                    break;
                                }
                            }
                            break;

                        case 6:
                            Console.WriteLine("\nDelete an Event (1)\n");
                            Console.WriteLine("\nExit to Menu (2)\n");
                            int a = Convert.ToInt16(Console.ReadLine());
                            if (a == 1)
                            {
                                var delupcount = db.Events.Count();
                                if (delupcount > 0)
                                {
                                    Console.WriteLine("\nAll Deletable Events!\n");
                                    var queryall = from b in db.Events orderby b.Title select b;

                                    foreach (var item in queryall)
                                    {
                                        item.printEvent();
                                    }

                                    Console.WriteLine("\nWhat EventID would you like to delete\n\nEventID:");
                                    var delid = Convert.ToInt16(Console.ReadLine());
                                    //ID is searched for
                                    Console.WriteLine("\nEventID-{0}-Selected\n", delid);
                                    var del = from b in db.Events where (b.EventID == delid) orderby b.Title select b;

                                    foreach (var item in del)
                                    {
                                        //Deletes Event with searched ID
                                        db.Events.Remove(item);
                                        item.deleteEvent();
                                    }
                                    try
                                    {
                                        db.SaveChanges();
                                    }
                                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                                    {
                                        Console.WriteLine("Error, could not delete event!");
                                    }
                                }
                            }
                            else if (a == 2)
                            {
                                //Option returns back to main menu
                                break;
                            }
                            break;
                        case 7:
                            //Closes the application
                            Console.WriteLine("GoodBye!");
                            break;

                        default:
                            Console.WriteLine("Please select a sufficient option!");
                            break;
                    }
                } while (option != 7);
            }
        }
    }
}
