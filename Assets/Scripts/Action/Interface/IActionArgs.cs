
using Action.Interface;

namespace Action.Interface
{
    public interface IActionArgs 
    {
        IActionTarget Indicator { get; set; }

        IActionTarget[] Targets { get; set; }
        
        object[] CustomData { get; set; }
    }
}
