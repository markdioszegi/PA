using System;

namespace Refrigerator
{

    public abstract class Consumable
    {
        private string name;
        private int calories;
        private DateTime bestBefore;
        public string Name { get => name; set => name = value; }
        public int Calories { get => calories; set => calories = value; }
        public DateTime BestBefore { get => bestBefore; set => bestBefore = value; }
        public bool IsDepraved()
        {
            if (DateTime.Now > BestBefore)
                return true;
            return false;
        }
        /* public override bool Equals(object obj)
        {
            obj = (Consumable)obj;
            if (Name == obj.Name)
                return true;
            return false;
        } */
        public override string ToString()
        {
            return $"Product name: {Name}\nCalories: {Calories} kcal\nBest before: {BestBefore.ToShortDateString()}";
        }
    }
}