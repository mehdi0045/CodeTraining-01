using System;
using System.Collections.Generic;
using Condition.Interface;
using Condition.InventorySystem;
using Enums.Types.Item;
using Extensions.Item;
using Inventory.Interface;

namespace Inventory.Base
{
    public class BaseInventory : IInventory
    {
        public BaseInventory(string id, string name, int slotCount, ICondition[] conditionsAdd,
            ICondition[] conditionsRemove)
        {
            Id = id;
            Name = name;
            _slotCount = slotCount;
            _conditionsAdd = conditionsAdd;
            _conditionsRemove = conditionsRemove;
        }
        
        public delegate void OnItemAddedDelegate(IInventory inventory, IItem item, int index);
        public event OnItemAddedDelegate OnItemAdded;

        public delegate void OnItemRemoveDelegate(IInventory inventory, IItem item, int index);
        public event OnItemRemoveDelegate OnItemRemove;

        public string Id { get; set; }

        public string Name { get; set; }
        
        public List<ISlot> Slots { get; set; }
        
        public IInventoryHandler[] Handlers { get; set; }

        private ICondition[] _conditionsAdd;
        private ICondition[] _conditionsRemove;

        public int _slotCount;
        
        public void Init()
        {
            Slots = new List<ISlot>();
            
            for (int i = 0; i < _slotCount; i++)
            {
                var slot = new BaseSlot(i);
                Slots.Add(slot);
            }
            
            Handlers = new IInventoryHandler[] {new BaseInventoryHandler(EnumIItemTypes.TypeA.ToString()),};
        }

        public IInteractionInventoryCallback Add(IItem item)
        {
            var iResult = CheckCondition(_conditionsAdd, item);
            
            if (iResult.Result)
            {
                var handler = FindHandler(item.Type);
                var callback = handler.Add(new BaseInventoryHandlerArgs(item, Slots));

                if (callback.Success)
                {
                    OnOnItemAdded(this, item ,callback.Index);
                }
                return callback;
            }
            
            var result = (ConditionInventoryCallback) iResult;
            return new BaseInteractionInventoryCallback(false, result.Status,-1);
        }

        public IInteractionInventoryCallback Remove(IItem item)
        {
            var iResult = CheckCondition(_conditionsRemove, item);
            
            if (iResult.Result)
            {
                var handler = FindHandler(item.Type);
                var callback = handler.Remove(new BaseInventoryHandlerArgs(item, Slots));
                if (callback.Success)
                {
                    OnOnItemRemove(this, item,callback.Index);
                }
                return callback;
            }
            
            var result = (ConditionInventoryCallback) iResult;
            return new BaseInteractionInventoryCallback(false, result.Status ,-1);
        }

        public IInteractionInventoryCallback Contain(IItem item)
        {
            foreach (var slot in Slots)
            {
                if (!slot.IsFree())
                {
                    if (slot.Item.IsEqual(item))
                    {
                        return new BaseInteractionInventoryCallback(true, (int) EnumInventoryStatuses.Success,slot.Index);
                    }
                }
            }
            return new BaseInteractionInventoryCallback(false, (int) EnumInventoryStatuses.ItemIsNotExist,-1);
        }

        private IInventoryHandler FindHandler(string type)
        {
            return Array.Find(Handlers, i => i.Type == type);
        }

        private IConditionCallback CheckCondition(ICondition[] conditions, IItem item)
        {
            foreach (var condition in conditions)
            {
                var callback = condition.Check(new ConditionInventoryArgs(this , item));
                if (callback.Result == false) return callback;
            }
            return new ConditionInventoryCallback(true, (int) EnumInventoryStatuses.Success);
        }
        
        #region Events

        protected virtual void OnOnItemAdded(IInventory inventory, IItem item ,int index)
        {
            OnItemAdded?.Invoke(inventory, item, index);
        }

        protected virtual void OnOnItemRemove(IInventory inventory, IItem item,int index)
        {
            OnItemRemove?.Invoke(inventory, item,index);
        }

        #endregion
    }
    
}