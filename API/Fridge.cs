using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Refrigerator
{
    [XmlInclude(typeof(Edible))]
    [XmlInclude(typeof(Drinkable))]
    public class Fridge : IStorable
    {
        string id;
        string brand;
        string modelName;
        int capacity;
        public List<Consumable> Consumables { get; set; }

        [XmlAttribute]
        public string ID { get => id; set => id = value; }
        [XmlAttribute]
        public string Brand { get => brand; set => brand = value; }
        [XmlAttribute]
        public string ModelName { get => modelName; set => modelName = value; }
        [XmlAttribute]
        public int Capacity { get => capacity; set => capacity = value; }

        public Fridge() { }
        public Fridge(string id, string brand, string modelName, int capacity)
        {
            ID = id;
            Brand = brand;
            ModelName = modelName;
            Capacity = capacity;
            Consumables = new List<Consumable>();
        }
        public void RemoveConsumable(Consumable consumable)
        {
            Consumables.Remove(consumable);
            UI.PrintInfo("Deleted!");
        }
        public void StoreConsumable(Consumable consumable)
        {
            if (Consumables.Count < Capacity)
            {
                Consumables.Add(consumable);
            }
            else
            {
                throw new FridgeIsFullException();
            }
        }
        public List<Consumable> FindConsumable(string input)
        {
            List<Consumable> consumables = new List<Consumable>();
            foreach (var consumable in Consumables)
            {
                if (consumable.Name.ToLower().Contains(input.ToLower()))
                {
                    consumables.Add(consumable);
                }
            }

            if (consumables.Count == 0)
            {
                throw new ConsumableNotFoundException();
            }
            else
            {
                return consumables;
            }
        }

        public List<Consumable> GetVeganFoods()
        {
            List<Consumable> veganEdibles = new List<Consumable>();
            foreach (var consumable in Consumables)
            {
                Edible edible = consumable as Edible;
                if (edible != null)
                {
                    if (edible.IsVegan())
                        veganEdibles.Add(edible);
                }
            }

            if (veganEdibles.Count == 0)
            {
                throw new ConsumableNotFoundException();
            }
            else
            {
                return veganEdibles;
            }
        }

        public List<Consumable> GetAlcoholicBeverages()
        {
            List<Consumable> alcoholicBeverages = new List<Consumable>();
            foreach (var consumable in Consumables)
            {
                Drinkable drinkable = consumable as Drinkable;
                if (drinkable != null)
                {
                    if (drinkable.IsAlcoholicBeverage())
                        alcoholicBeverages.Add(drinkable);
                }
            }

            if (alcoholicBeverages.Count == 0)
            {
                throw new ConsumableNotFoundException();
            }
            else
            {
                return alcoholicBeverages;
            }
        }

        public override string ToString()
        {
            return $"ID: {ID}, Brand: {Brand}, Model name: {ModelName}, Capacity: {Capacity} products";
        }
    }
}