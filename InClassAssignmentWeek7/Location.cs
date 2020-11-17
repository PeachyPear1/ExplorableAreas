using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace InClassAssignmentWeek7
{
    public class Location
    {
        //A new string called name in the Location class that gets whatever is put in and sets whatever is put in
        public string Name
        {
            get; set;
        }

        //A new string called Description in the Location class that gets whatever is put in and sets whatever is put in
        public string Description
        {
            get; set;
        }

        //A new list called Items in the Location class that gets whatever is put in and sets whatever is put in
        public List<Item> Items
        {
            get; set;
        }

        //An instance of consolecolor that is used to get whatever is put in and set it to whatever is put in for the term LocationColor
        public ConsoleColor LocationColor
        {
            get; set;
        }

        //A new list called RequiredItems in the Location class that gets whatever is put in and sets whatever is put in
        public List<Item> RequiredItems
        {
            get; set;
        }

        //An instance of the Location class
        public Location() { }

        //Another instance of the Location class that is used to overload it by calling name, description, a list of items, a list of required items, and color
        public Location(string name, string description, List<Item> items, List<Item> requiredItems, ConsoleColor color)
        {
            Name = name;
            Description = description;
            Items = items;
            RequiredItems = requiredItems;
            LocationColor = color;
        }

        //A method that prints the line to the console window with the strings in the curly braces by calling them and setting them in the string written
        public void PrintLocationInfo()
        {
            WriteLine($"You are at {Name}.  {Description}");
        }
    }
}