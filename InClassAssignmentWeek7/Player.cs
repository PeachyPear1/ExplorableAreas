using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace InClassAssignmentWeek7
{
    public class Player
    {
        //A new string called name in the Player class that gets whatever is put in and sets whatever is put in
        public string Name { get; set; }

        //A new instance of Location that is called CurrentLocation that gets whatever is put in and sets whatever is put in
        public Location CurrentLocation { get; set; }

        //creates player with default empty list
        //Creates a new list that is set to inventory
        public List<Item> Inventory = new List<Item>();

        //prints current player inventory to console
        //A new method in the Player class called PrintInventory
        public void PrintInventory()
        {
            //creates list of names of items
            //Creates a new list that is for names
            List<string> names = new List<string>();

            //for each item in the player's inventory, this loop adds the name of the item to the inventory
            //A foreach loop that adds the name of the items in the player's inventory to the actual inventory
            foreach (var item in Inventory)
            {
                names.Add(item.Name);
            }

            //this uses string.join to join the strings together and print them out with commas separating
            //This uses the function of string called Join to put two strings together and then print them out with the formatting provided
            string ListOfNames = String.Join(", ", names);

            //inline if statement, "it looks a lot cooler, right?" (question mark operator)
            //uses question mark to check validity of the statement.  if it is true, it uses the first part.  if not, it uses the second.  Question mark acts like a boolean of sorts.
            //Checks the inventory for how many items are in it and provides the proper noun depending on the result
            string ItemLabel = Inventory.Count == 1 ? "item" : "items";
            //Checks the inventory for grammar issues and provides the proper usage to have correct grammar depending on the result
            string Grammar = Inventory.Count == 1 ? "it is" : "they are";

            //this prints the inventory with the newly added information :)
            //Writes the string to the console with the other strings that are in curly braces through being called
            WriteLine($"You currently have {Inventory.Count} {ItemLabel} and {Grammar} {ListOfNames}.");



        }

        //An instance of the Player class
        public Player()
        {

        }

        //A method that is used to add an item to the inventory and give the user positive feedback that they did, indeed, pick up an item. Also prints the inventory to the console
        public void CollectItem(Item item)
        {
            Inventory.Add(item);
            WriteLine($"You picked up {item.Name}.");
            PrintInventory();
        }

       
    }
}