/*
 * week 7 in class assignment
 * drivin by Ashlyn during class
 * 
 * Completed by Michael after class
 * 
 * Comments by Hannah Hamilton
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using static System.Console;

namespace InClassAssignmentWeek7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sets window title
            Title = "Empty Jetpack Joyride";

            //Creates new Item
            Item CandyJetpack = new Item("Candy Jetpack", "It allows you to fly!  Unfortunately, fuel was not included.");
            //Creates new Item
            Item ClimbingGear = new Item("Climbing Gear", "No fuel required.");
            //Creates new Item
            Item Fuel = new Item("Hot Fudge", "Can be used as fuel.  Probably for a Jetpack but that's up to you.");
            //Creates new Item
            Item CandyCrown = new Item("Candy Crown", "The ultimate head gear.  Gives you all of the Candy that exists (And sovereignty over Candy World).");
            //Creates new Item
            Item AllTheCandy = new Item("All of the Candy", "Literally just all of it. Gives you access to the win command");

            //Creates new Location
            Location ClimbingStore = new Location("Climbing Store", "A store that serves all of your Candy Mountain climbing needs.", new List<Item> { ClimbingGear }, new List<Item> { }, ConsoleColor.Cyan);
            //Creates new Location
            Location CandyMountain = new Location("Candy Mountain", "It's a mountain.  Of candy. You might need something to help you get up there.", new List<Item> {CandyJetpack}, new List<Item> {ClimbingGear}, ConsoleColor.Magenta);
            //Creates new Location
            Location House = new Location("Your House", "You live here!", new List<Item> {Fuel}, new List<Item> {}, ConsoleColor.DarkGreen);

            //create object without method!
            //Creates location without the use of a method
            Location CottonCandyCloud = new Location()
            {
                //Set location name
                Name = "Cotton Candy Cloud",
                //Sets location description
                Description = "A piece of Cotton Candy so large and light that it just became a cloud. You would have to fly to get up to here.",
                //Creates a new list of items with the candy crown in it to start
                Items = new List<Item> { CandyCrown},
                //Creates a new list of items describing what will be neeeded to proceed in a location
                RequiredItems = new List<Item> { CandyJetpack, Fuel },
                //Gives the location a color
                LocationColor = ConsoleColor.Yellow
            };
            //Creates location without the use of a method
            Location CandyThrone = new Location()
            {
                //Set location name
                Name = "The Candy Throne",
                //Sets location description
                Description = "A throne of candy. Only those who wear the candy crown can enter the candy throne.",
                //Creates a new list of items with all the candy in it to start
                Items = new List<Item> { AllTheCandy},
                //Creates a new list of items describing what will be neeeded to proceed in a location
                RequiredItems = new List<Item> { CandyCrown},
                //Gives the location a color
                LocationColor = ConsoleColor.Cyan
            };

            //Creates a list of the locations
            List<Location> Locations = new List<Location>() {House, CandyMountain, ClimbingStore, CottonCandyCloud, CandyThrone};

            //Creates a new instance of the Player
            Player Player1 = new Player();

            //Creates a new instance of the world
            World world = new World("Candy World", Player1, House, Locations, AllTheCandy);
            //Calls the Menu method from the world class
            world.Menu();
        }
    }
}
