using System;
using System.Collections.Generic;
using System.Text;

namespace Object_Oriented_Programming_Assignment
{
    class CalMenu
    {       
        public CalMenu()
        {
            string menu;
            Console.WriteLine("Welcome to the Main Menu of the Calander!\n" +
                "1) See all events in date order\n" +
                "2) Print internal calender events\n" +
                "3) Print external calender events\n" +
                "4) Exit");
            menu = Console.ReadLine();

            //Console.WriteLine(menu);

            //CalMenu menu = new CalMenu(); //Object Oriented Menu Test
            //Console.WriteLine(menu);
            //Console.ReadKey();

            //2 - Print Menu (Switch statement)
            while (menu != "4")
            {
                switch (menu)
                {
                    case "1":
                        Console.WriteLine("Test 1");
                        break;

                    case "2":
                        Console.WriteLine("Test 2");
                        break;

                    case "3":
                        Console.WriteLine("Test 3");
                        break;

                    case "4":
                        break;

                    default:
                        Console.WriteLine("Please select a sufficient option!");
                        break;
                }
                menu = Console.ReadLine();
            }
        }
    }
}
