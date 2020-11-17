using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace InClassAssignmentWeek7
{
    public class Item
    {
        //An instance of the class of Item
        public Item(string name, string description)
        {
            //Sets the name to be whatever is inputted to name later on
            Name = name;
            //Sets the description to be whatever is inputted to description later on
            Description = description;
        }

        //A new string called name in the Item class that gets whatever is put in and sets it to whatever is put in
        public string Name
        {
            get; set;
        }

        //A new string called Description in the Item class that gets whatever is put in and sets it to whatever is put in
        public string Description
        {
            get; set;
        }
    }
}