using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Console;

namespace InClassAssignmentWeek7
{
    public class World
    {
        //A list called locations that gets whatever is put into it and sets whatever is put into it
        public List<Location> Locations {get; set;}

        //A string that is called name in the World class that gets whatever is put into it and sets whatever is put into it
        public string Name
        {
            get; set;
        }

        //An instance of the Player class called CurrentPlayer that gets whatever is put into it and sets whatever is put into it
        public Player CurrentPlayer
        {
            get; set;
        }

        //An instance of the Item class called WinCondition that gets whatever is put into it and sets whatever is put into it
        public Item WinCondition { get; set; }

        //An instance of the World class that is used to overload it by plugging in the string name, the player, the location, the list of locations, and the item win condition
        public World(string name, Player player, Location defaultLocation, List<Location> locations, Item winCondition)
        {
            Name = name;
            CurrentPlayer = player;
            CurrentPlayer.CurrentLocation = defaultLocation;
            Locations = locations;
            WinCondition = winCondition;
            SetUpPlayer();
        }

        //A method called SetUpPlayer in the World class that welcomes the player, stores their name, and relates their current location
        public void SetUpPlayer()
        {
            WriteLine($"Welcome to {Name}!");
            CurrentPlayer.Name = Utility.GetUserInput("What is your name?");
            WriteLine($"Your current location is {CurrentPlayer.CurrentLocation.Name}.");
        }

        //A true false statement that provides the location and location description. It then asks the user where they would like to go. It first checks if the player meets all the requirements to go there, then updates where they are dependant on that
        public bool ChangeLocation()
        {
            int index = 1;
            foreach (var Location in Locations)
            {
                WriteLine($"{index++}: {Location.Name} \n{Location.Description}");
            }

            int userChoice = 0;
            string userInput = Utility.GetUserInput("Where would you like to go?");
            int.TryParse(userInput, out userChoice);
            if (userChoice > 0 && userChoice <= Locations.Count)
            {
                userChoice--;
                Location newLocation = Locations[userChoice];
                //this checks whether or not the player is in possesion of the required item, we start with true because there are some instances where a location has no required items.
                bool HasRequiredItems = true;

                //the loop checks to see if the items are NOT in the inventory.  the loop breaks when ONE item is not present.
                foreach (var Item in newLocation.RequiredItems)
                {
                    if (!CurrentPlayer.Inventory.Contains(Item))
                    {
                        HasRequiredItems = false;
                        break;
                    }
                }

                if (HasRequiredItems)
                {
                    CurrentPlayer.CurrentLocation = newLocation;
                    return true;
                }
                else
                {
                    WriteLine("Uh oh.  You're missing something! You don't have what you need to go there.");
                    return false;
                }
            }
            WriteLine("That's not somewhere you can go");
            return false;

        }

        //A method that displays all the items in the location to the user on the console window. Gives the option to the user to choose which item they would like to pick up through a TryParse and conditional statement
        public void DisplayLocationItems()
        {
            if (CurrentPlayer.CurrentLocation.Items.Count > 0)
            {
                int index = 1;
                WriteLine($"There are some items laying around.");

                foreach (var Item in CurrentPlayer.CurrentLocation.Items)
                {
                    WriteLine($"{index++}: {Item.Name} \n{Item.Description}");
                }

                int userChoice = 0;
                string userInput = Utility.GetUserInput("Which item would you like to pick up?");
                int.TryParse(userInput, out userChoice);
                if (userChoice > 0 && userChoice <= CurrentPlayer.CurrentLocation.Items.Count)
                {
                    userChoice--;
                    Item PickedUpItem = CurrentPlayer.CurrentLocation.Items[userChoice];
                    CurrentPlayer.CollectItem(PickedUpItem);
                    CurrentPlayer.CurrentLocation.Items.Remove(PickedUpItem);
                }
                else
                {
                    WriteLine("That is not an available item");
                }

            }
            else
            {
                WriteLine("There are no more items here.");
            }
        }

        //A method that welcomes the player to the game and starts a while loop with a switch. Provides the proper case dependant on all variables taken in from the application
        public void Menu()
        {
            Clear();
            Console.WriteLine($"Welcome {CurrentPlayer.Name} to the world of {Name}. " +
                $"\n\nThis is an text based game where you explore different areas using commands typed into a the console." +
                $"\nTo see the commands you can use type the word 'help' and hit enter. To enter other commands type in the command and hit enter." +
                $"\nIf you change the size of your window use the clear command to reset the top bar.\n\nHave fun");
            bool WinTheGame = false;
            bool quit = false;
            while (!WinTheGame && !quit)
            {
                switch (ReadLine().ToLower().Trim())
                {
                    case "move":
                        if (ChangeLocation()) {
                        Clear();
                        WriteLine($"You are now in {CurrentPlayer.CurrentLocation.Name}");
                        }
                        break;
                    case "search":
                        DisplayLocationItems();
                        break;
                    case "clear":
                        Clear();
                        break;
                    case "help":
                        WriteLine("Available Commands: Inventory, Search, Clear, Move, Win (you can only do this when you have all the candy), Quit (you don't want to do this)");
                        break;
                    case "inventory":
                        CurrentPlayer.PrintInventory();
                        break;
                    case "win":
                        if (CurrentPlayer.Inventory.Contains(WinCondition))
                        {
                            WinTheGame = true;
                            WriteLine($"Hooray you collected all the candy and won the game. Press any key to close the console");
                            ReadKey();
                        }
                        else
                        {
                            WriteLine("Silly you cant do that yet. You haven't collected all the candy");
                        }
                        break;
                    case "quit":
                        if (Utility.Affirm("Are you sure you really want to quit?"))
                        {
                            quit = true;
                            WriteLine("Ok then. press any key to close the window");
                            ReadKey();
                        }
                        break;
                    default:
                        Console.WriteLine("Unknown command. Type 'help' for a list of commands.");
                        break;
                }
            }
        }

        //A method that clears the screen and puts things back to the default screen of the player's name, location, and what they have in their inventory
        public void Clear()
        {
            Console.Clear();
            Utility.Line();
            Utility.Center($"Player: {CurrentPlayer.Name}  Location: {CurrentPlayer.CurrentLocation.Name}  Inventory: {CurrentPlayer.Inventory.Count}");
            Utility.Line();
        }
        
        
    }
}