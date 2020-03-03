using System;
using System.ComponentModel;

namespace Refrigerator
{
    public enum EdibleType
    {
        VEGETABLE = 1,
        FRUIT,
        MEAT,
        FISH,
        DAIRY_PRODUCT
    }
    public class Edible : Consumable
    {
        EdibleType edibleType;
        public EdibleType EdibleType { get => edibleType; set => edibleType = value; }
        public Edible() { }
        public Edible(string name, int calories, DateTime bestBefore, EdibleType edibleType)
        {
            Name = name;
            Calories = calories;
            BestBefore = bestBefore;
            EdibleType = edibleType;
        }

        public bool IsVegan()
        {
            if (EdibleType == EdibleType.MEAT)
                return false;
            return true;
        }
        public override string ToString()
        {
            return base.ToString() + $"\nType: {EdibleType}";
        }
    }
}