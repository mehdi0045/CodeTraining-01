using Action.Interface;

namespace Action.Base
{
    public class BaseActionArgs : IActionArgs
    {
        public IActionTarget Indicator { get; set; }
        
        public IActionTarget[] Targets { get; set; }
        
        public object[] CustomData { get; set; }
    }
}
