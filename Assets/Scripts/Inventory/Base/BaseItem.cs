using Inventory.Interface;

namespace Inventory.Base
{
    public class BaseItem : IItem
    {
        public BaseItem(string id, string name, string type)
        {
            Id = id;
            Name = name;
            Type = type;
        }

        public string Id { get; set; }
        
        public string Name { get; set; }
        
        
        public string Type { get; set; }
    }
}
