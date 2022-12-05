using Condition.Interface;

namespace Condition.InventorySystem
{
    public struct ConditionInventoryCallback : IConditionCallback
    {
        public ConditionInventoryCallback(bool result, int status)
        {
            Result = result;
            Status = status;
        }

        public bool Result { get; set; }
        public int Status { get; set; }
    }
}
