using System.Collections.Generic;
using System.Threading.Tasks;
using Action.Interface;
using Enums.Statuses;

namespace Action.Base
{
    public class BaseAction : IAction
    {
        public BaseAction(string id, string name, IActionSequence[] actionSteps)
        {
            Id = id;
            Name = name;
            ActionSteps = actionSteps;
        }

        public string Id { get; set; }
    
        public string Name { get; set; }
    
        public IActionSequence[] ActionSteps { get; set; }

        public async Task<IInteractionCallBack> Action(IActionArgs iArgs)
        {
            var customData = new Dictionary<string, object>();
            
            foreach (var step in ActionSteps)
            {
                await step.ActionStep(iArgs,customData);
            }
            return new BaseInteractionCallback((int) EnumActionStatuses.ActionStart);
        }
    }
}
