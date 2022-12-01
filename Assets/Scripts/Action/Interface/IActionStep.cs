using System.Collections.Generic;
using System.Threading.Tasks;
using Action.Interface;

namespace Action
{
    public interface IActionStep 
    {
        string Id { get; set; }
        
        string Name { get; set; }

        Task<IInteractionCallBack> ActionStep(IActionArgs iArgs, Dictionary<string, object> customData);
    }
}
