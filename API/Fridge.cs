using System;
using System.Collections.Generic;
using System.IO;
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

        public string ID { get => id; set => id = value; }
        public string Brand { get => brand; set => brand = value; }
        public string ModelName { get => modelName; set => modelName = value; }
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

        public void SaveToXML(string fileName)
        {
            UI.PrintInfo($"Saved everything to {fileName}!");
            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Fridge));
                xml.Serialize(fileStream, this);
            }
        }

        public static Fridge LoadFromXML(string fileName)
        {
            UI.PrintInfo($"Loaded everything from {fileName}!");
            using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Fridge));
                return (Fridge)xml.Deserialize(fileStream);
            }
        }

        public override string ToString()
        {
            return $"ID: {ID}, Brand: {Brand}, Model name: {ModelName}, Capacity: {Capacity} products";
        }
    }
}