using System.Collections.Generic;
using System.Threading.Tasks;
using Action.Interface;
using UnityEngine;

namespace Action.Steps
{
    public class ActionStep1 : IActionStep
    {
        public ActionStep1()
        {
            Id = "0";
            Name = "Log 1";
        }

        public string Id { get; set; }
        
        public string Name { get; set; }

        public async Task<IInteractionCallBack> ActionStep(IActionArgs iArgs ,Dictionary<string, object> customData)
        {
            var callbackStart = new BaseInteractionCallback((int) EnumActionStatus.ActionStart);
            Debug.Log((EnumActionStatus)callbackStart.Status);
            Debug.Log("1");
            await Task.Delay(1000);
            Debug.Log("2");
            await Task.Delay(1000);
            
            customData.Add("Hp", "mehdi khookhi");
            
            var callbackEnd = new BaseInteractionCallback((int) EnumActionStatus.ActionEnd);
            Debug.Log((EnumActionStatus)callbackEnd.Status);
            return callbackEnd;
        }
    }
}
