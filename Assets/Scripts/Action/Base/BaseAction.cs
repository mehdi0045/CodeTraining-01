using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Action.Interface;

namespace Action.Base
{
    public class BaseAction : IAction
    {
        public BaseAction(string id, string name, IActionStep[] actionSteps)
        {
            Id = id;
            Name = name;
            ActionSteps = actionSteps;
        }

        public string Id { get; set; }
    
        public string Name { get; set; }
    
        public IActionStep[] ActionSteps { get; set; }

        public async Task<IInteractionCallBack> Action(IActionArgs iArgs)
        {
            var customData = new Dictionary<string, object>();
            
            foreach (var step in ActionSteps)
            {
                await step.ActionStep(iArgs,customData);
            }
            return new BaseInteractionCallback((int) EnumActionStatus.ActionStart);
        }
    }
}
