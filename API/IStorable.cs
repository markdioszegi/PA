using System.Collections.Generic;

namespace Refrigerator
{
    public interface IStorable
    {
        void StoreConsumable(Consumable consumable);
    }
}