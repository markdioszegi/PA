using System;

namespace Refrigerator
{
    public class Drinkable : Consumable
    {
        float alcoholByVolume;
        public float AlcoholByVolume { get => alcoholByVolume; set => alcoholByVolume = value; }
        public Drinkable() { }
        public Drinkable(string name, int calories, DateTime bestBefore, float alcoholByVolume)
        {
            Name = name;
            Calories = calories;
            BestBefore = bestBefore;
            AlcoholByVolume = alcoholByVolume;
        }

        public bool IsAlcoholicBeverage()
        {
            if (AlcoholByVolume > 0)
                return true;
            return false;
        }
        public override string ToString()
        {
            return base.ToString() + $"\nStrength: {AlcoholByVolume}%";
        }
    }
}