using System.Collections.Generic;

namespace Refrigerator
{
    public interface IStorable
    {
        void CreateConsumable();
        void RemoveConsumable(Consumable consumable);
        void StoreConsumable(Consumable consumable);
        List<Consumable> FindConsumable(string input);
        List<Consumable> GetVeganFoods();
        List<Consumable> GetAlcoholicBeverages();
    }
}