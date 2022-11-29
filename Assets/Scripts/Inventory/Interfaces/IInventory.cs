using System.Collections.Generic;

namespace InventorySystem
{
   public interface IInventory
   {
      string Id { get; set; }
      
      public string Name { get; set; }
      
      List<ISlot> Slots { get; set; }
      
      IInventoryHandler[] Handlers { get; set; }
      
      void Init();
      
      IInteractionInventoryCallback Add(IItem item);
   
      IInteractionInventoryCallback Remove(IItem item);
   
      IInteractionInventoryCallback Contain(IItem item);
   }
}
