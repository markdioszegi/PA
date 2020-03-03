using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Refrigerator
{
    public static class DataManager
    {
        public static void SaveToXML(string fileName, List<Fridge> fridges)
        {
            UI.PrintInfo($"Saved everything to {fileName}!");
            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                XmlSerializer xml = new XmlSerializer(fridges.GetType(), new XmlRootAttribute("Fridges"));
                xml.Serialize(fileStream, fridges);
            }
        }

        public static List<Fridge> LoadFromXML(string fileName, List<Fridge> fridges)
        {
            if (File.Exists(fileName))
            {
                UI.PrintInfo($"Loaded everything from {fileName}!");
                using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    XmlSerializer xml = new XmlSerializer(fridges.GetType(), new XmlRootAttribute("Fridges"));
                    return (List<Fridge>)xml.Deserialize(fileStream);
                }
            }
            return fridges;
        }
    }
}