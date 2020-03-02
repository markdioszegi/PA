using System;
using System.Collections.Generic;

namespace Refrigerator
{
    public class Menu
    {
        List<Fridge> Fridges;
        public Menu()   //TODO
        {
            LoadFridges();
            MainMenu();
        }

        void LoadFridges()  //load from xml
        {
            Fridges = new List<Fridge>();
            Fridge fridge = new Fridge("F1", "Zanussi", "ZFC500", 10);
            Fridge fridge2 = new Fridge("F2", "Zanussi", "ZFC600", 10);
            Edible edible = new Edible("Egg", 155, new DateTime(2020, 03, 22), EdibleType.DAIRY_PRODUCT);
            Edible edible2 = new Edible("Chicken breast", 350, new DateTime(2020, 03, 22), EdibleType.MEAT);
            Drinkable drink = new Drinkable("Vodka", 35, new DateTime(2100, 1, 1), 37.5f);
            Drinkable drink2 = new Drinkable("Vodka", 35, new DateTime(2100, 1, 1), 37.5f);
            System.Console.WriteLine(drink.Equals(drink2));
            fridge.StoreConsumable(drink);
            fridge.StoreConsumable(edible);
            fridge.SaveToXML(Program.FileName);
            fridge2.StoreConsumable(drink);
            fridge2.StoreConsumable(edible);
            fridge2.SaveToXML(Program.FileName);
            //fridge = Fridge.LoadFromXML(Program.FileName);
            //fridge2 = Fridge.LoadFromXML(Program.FileName);
            Fridges.Add(fridge);
            Fridges.Add(fridge2);
        }

        void MainMenu()
        {
            UI.PrintInfo("Choose a fridge by ID!");
            foreach (var fridge in Fridges)
            {
                UI.PrintInfo("Fridge details: " + fridge.ToString());
            }
            while (true)
            {
                string input = Console.ReadLine().ToUpper();
                foreach (var fridge in Fridges)
                {
                    if (input == fridge.ID)
                    {
                        FridgeMenu(fridge);
                    }
                }
            }
        }

        void FridgeMenu(Fridge fridge)
        {
            UI.PrintInfo("Welcome to the Fridge Manager! Type in a command to do something.");
            while (true)
            {
                UI.PrintInfo("Fridge details: " + fridge.ToString());
                UI.PrintInfo("Commands: ");
                UI.PrintLine("list:\tlist the contents of the fridge");
                UI.PrintLine("find:\tfind an element by name");
                UI.PrintLine("new:\tcreate an element");
                UI.PrintLine("remove:\tremove and element");

                UI.PrintLine("exit:\tterminate program");
                switch (Console.ReadLine())
                {
                    case "list":
                        UI.PrintContents(fridge);
                        break;
                    case "find":

                        break;
                    case "new":

                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        UI.PrintError("No such command!");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}