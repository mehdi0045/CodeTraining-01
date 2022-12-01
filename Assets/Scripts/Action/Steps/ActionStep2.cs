using System.Collections.Generic;
using System.Threading.Tasks;
using Action.Interface;
using UnityEngine;

namespace Action
{
    public class ActionStep2 : IActionStep
    {
        public ActionStep2()
        {
            Id = "0";
            Name = "Log 1";
        }
        public ActionStep2(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        
        public string Name { get; set; }

        public async Task<IInteractionCallBack> ActionStep(IActionArgs iArgs,Dictionary<string, object> customData)
        {
            var callbackStart = new BaseInteractionCallback((int) EnumActionStatus.ActionStart);
            Debug.Log((EnumActionStatus)callbackStart.Status);
            Debug.Log(customData["Hp"]);
            await Task.Delay(1000);
            Debug.Log("4");
            await Task.Delay(1000);
            var callbackEnd = new BaseInteractionCallback((int) EnumActionStatus.ActionEnd);
            Debug.Log((EnumActionStatus)callbackEnd.Status);
            return callbackEnd;
        }
    }
}
