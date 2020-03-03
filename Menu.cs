using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;

namespace Refrigerator
{
    public class Menu
    {
        Fridge selectedFridge;
        List<Fridge> Fridges;
        public Menu()   //TODO
        {
            Fridges = new List<Fridge>();
            LoadFridges();
            MainMenu();
        }

        void LoadFridges()  //load from xml
        {
            /* Fridge fridge = new Fridge("F1", "Zanussi", "ZFC500", 10);
            Fridge fridge2 = new Fridge("F2", "Zanussi", "ZFC600", 10);
            Edible edible = new Edible("Egg", 155, new DateTime(2020, 03, 22), EdibleType.DAIRY_PRODUCT);
            Edible edible2 = new Edible("Chicken breast", 350, new DateTime(2020, 03, 22), EdibleType.MEAT);
            Drinkable drink = new Drinkable("Vodka", 35, new DateTime(2100, 1, 1), 37.5f);
            //System.Console.WriteLine(drink.Equals(drink2));
            fridge.StoreConsumable(drink);
            fridge.StoreConsumable(edible);
            fridge2.StoreConsumable(edible2);
            Fridges.Add(fridge);
            Fridges.Add(fridge2);
            SaveToXML(Program.FileName); */
            Fridges = DataManager.LoadFromXML(Program.FileName, Fridges);
        }

        void MainMenu()
        {
            while (true)
            {
                UI.PrintInfo("Choose a fridge by ID! or type in \"new\" to create one.");
                foreach (var fridge in Fridges)
                {
                    UI.PrintInfo("Fridge details: " + fridge.ToString());
                }
                string input = Console.ReadLine();
                if (input == "new")
                {
                    bool accepted = false;
                    string id = string.Empty;
                    while (!accepted)
                    {
                        id = UI.GetInput("ID: ");
                        if (Fridges.Count != 0)
                            foreach (var fridge in Fridges)
                            {
                                if (id == fridge.ID)
                                {
                                    UI.PrintError("ID already exists in that xml!");
                                }
                                else
                                {
                                    accepted = true;
                                }
                            }
                        else
                        {
                            accepted = true;
                        }
                    }
                    string brand = UI.GetInput("Brand: ");
                    string modelName = UI.GetInput("Model name: ");
                    int capacity = Convert.ToInt32(UI.GetInput("Capacity (products): "));
                    Fridges.Add(new Fridge(id, brand, modelName, capacity));
                }
                else
                {
                    foreach (var fridge in Fridges)
                    {
                        if (input == fridge.ID)
                        {
                            Console.Clear();
                            selectedFridge = fridge;
                            FridgeMenu();
                        }
                    }
                }
                Console.Clear();
            }
        }

        void FridgeMenu()
        {
            UI.PrintInfo("Welcome to the Fridge Manager! Type in a command to do something.");
            while (true)
            {
                UI.PrintInfo("Fridge details: " + selectedFridge.ToString());
                UI.PrintInfo("Commands: ");
                UI.PrintLine("list:\tlist the contents of the fridge");
                UI.PrintLine("vegan:\tlist the contents of vegan foods");
                UI.PrintLine("alcohol:\tlist the contents of alcoholic beverages");
                UI.PrintLine("find:\tfind an element by name");
                UI.PrintLine("new:\tcreate an element by name");
                UI.PrintLine("rm:\tremove an element by name");

                UI.PrintLine("exit:\tterminate program");
                switch (UI.GetInput())
                {
                    case "list":
                        UI.PrintContents(selectedFridge.Consumables);
                        break;
                    case "vegan":
                        try
                        {
                            UI.PrintContents(selectedFridge.GetVeganFoods());
                        }
                        catch (ConsumableNotFoundException ce)
                        {
                            UI.PrintError(ce.Message);
                        }
                        break;
                    case "alcohol":
                        try
                        {
                            UI.PrintContents(selectedFridge.GetAlcoholicBeverages());
                        }
                        catch (ConsumableNotFoundException ce)
                        {
                            UI.PrintError(ce.Message);
                        }
                        break;
                    case "find":
                        UI.PrintInfo("Product name: ");
                        try
                        {
                            UI.PrintContents(selectedFridge.FindConsumable(UI.GetInput()));
                        }
                        catch (ConsumableNotFoundException ce)
                        {
                            UI.PrintError(ce.Message);
                        }
                        break;
                    case "new":
                        UI.PrintInfo("Edible (e) or Drinkable (d)?");
                        try
                        {
                            GetValidatedInput(UI.GetInput());
                        }
                        catch (FridgeIsFullException fe)
                        {
                            UI.PrintError(fe.Message);
                        }
                        break;
                    case "rm":
                        UI.PrintInfo("Product name: ");
                        try
                        {
                            selectedFridge.RemoveConsumable(selectedFridge.FindConsumable(Console.ReadLine())[0]);
                        }
                        catch (ConsumableNotFoundException ce)
                        {
                            UI.PrintError(ce.Message);
                        }
                        break;
                    case "exit":
                        DataManager.SaveToXML(Program.FileName, Fridges);
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
        void GetValidatedInput(string type)
        {
            switch (type.ToLower())
            {
                case "e":
                    CreateEdible();
                    break;
                case "d":
                    CreateDrinkable();
                    break;
                default:
                    UI.PrintError("Invalid type!");
                    break;
            }
        }

        void CreateDrinkable()
        {
            UI.PrintInfo("Fill in the blank!");
            Drinkable edible = new Drinkable();
            DateTime dateTime;
            string[] descriptions = new string[4];
            descriptions[0] = "Name (string): ";
            descriptions[1] = "Calories (int): ";
            descriptions[2] = "Best before (yyyyMMdd): ";
            descriptions[3] = "Alcohol volume (float (e.g.: 66,9)): ";

            edible.Name = UI.GetInput(descriptions[0]);
            edible.Calories = Convert.ToInt32(UI.GetInput(descriptions[1]));
            DateTime.TryParseExact(UI.GetInput(descriptions[2]), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);
            edible.AlcoholByVolume = float.Parse(UI.GetInput(descriptions[3]));
            edible.BestBefore = dateTime;

            selectedFridge.StoreConsumable(edible);
            UI.PrintInfo("Product added!");
        }

        void CreateEdible()
        {
            UI.PrintInfo("Fill in the blank!");
            Edible edible = new Edible();
            DateTime dateTime;
            string[] descriptions = new string[4];
            descriptions[0] = "Edible type (1 - Vegetable, 2 - Fruit, 3 - Meat, 4 - Fish, 5 - Dairy Product): ";
            descriptions[1] = "Name (string): ";
            descriptions[2] = "Calories (int): ";
            descriptions[3] = "Best before (yyyyMMdd): ";

            edible.EdibleType = (EdibleType)Convert.ToInt32(UI.GetInput(descriptions[0]));
            edible.Name = UI.GetInput(descriptions[1]);
            edible.Calories = Convert.ToInt32(UI.GetInput(descriptions[2]));
            DateTime.TryParseExact(UI.GetInput(descriptions[3]), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);
            edible.BestBefore = dateTime;

            selectedFridge.StoreConsumable(edible);
            UI.PrintInfo("Edible added!");
        }
    }
}