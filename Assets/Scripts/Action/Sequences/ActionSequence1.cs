using System.Collections.Generic;
using System.Threading.Tasks;
using Action.Base;
using Action.Interface;
using Enums.Statuses;
using UnityEngine;

namespace Action.Sequences
{
    public class ActionSequence1 : IActionSequence
    {
        public ActionSequence1()
        {
            Id = "0";
            Name = "Log 1";
        }

        public string Id { get; set; }
        
        public string Name { get; set; }

        public async Task<IInteractionCallBack> ActionStep(IActionArgs iArgs ,Dictionary<string, object> customData)
        {
            var callbackStart = new BaseInteractionCallback((int) EnumActionStatuses.ActionStart);
            Debug.Log((EnumActionStatuses)callbackStart.Status);
            Debug.Log("1");
            await Task.Delay(1000);
            Debug.Log("2");
            await Task.Delay(1000);
            
            customData.Add("Hp", "mehdi khookhi");
            
            var callbackEnd = new BaseInteractionCallback((int) EnumActionStatuses.ActionEnd);
            Debug.Log((EnumActionStatuses)callbackEnd.Status);
            return callbackEnd;
        }
    }
}
