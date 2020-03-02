using System;
using System.Text;

namespace Refrigerator
{
    public class Program
    {
        public static string FileName;
        public static void Main(string[] args)
        {
            FileName = args[0];
            Console.OutputEncoding = Encoding.UTF8;     //UTF 8 encoding
            /* Fridge fridge = new Fridge("F01", "Zanussi", "ZFC500", 10);
            Edible edible = new Edible("Egg", 155, new DateTime(2020, 03, 22), EdibleType.DAIRY_PRODUCT);
            Edible edible2 = new Edible("Chicken breast", 350, new DateTime(2020, 03, 22), EdibleType.MEAT);
            Drinkable drink = new Drinkable("Vodka", 35, new DateTime(2100, 1, 1), 37.5f);
            UI.PrintInfo("" + edible2.IsVegan());
            UI.PrintInfo("" + drink.IsAlcoholicBeverage());
            fridge.StoreConsumable(drink);
            fridge.StoreConsumable(edible); */
            Menu menu = new Menu();
        }
    }
}