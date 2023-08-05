using StaticData;

namespace Inventory
{
    public interface IInventoryStaticDataService
    {
        public InventoryItemStaticData GetRandomItem();
    }
}