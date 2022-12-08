using System.Collections.Generic;
using System.Threading.Tasks;
using Action.Base;
using Action.Interface;
using Enums.Statuses;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Action.Sequences
{
    public class ActionJumpSequence : IActionSequence
    {
        public ActionJumpSequence(Rigidbody rb)
        {
            Id = "0";
            Name = "Log 1";
            _rb = rb;
        }
        public string Id { get; set; }
        
        public string Name { get; set; }

        private Rigidbody _rb;
        
        private float _speed;

        
        public async Task<IInteractionCallBack> ActionStep(IActionArgs iArgs, Dictionary<string, object> customData)
        {
            var callbackStart = new BaseInteractionCallback((int) EnumActionStatuses.ActionStart);
            Debug.Log((EnumActionStatuses)callbackStart.Status);
            
            _rb.AddForce(Vector3.up * 200);
            _rb.AddForce(Vector3.forward * 200);
            
            var callbackEnd = new BaseInteractionCallback((int) EnumActionStatuses.ActionEnd);
            Debug.Log((EnumActionStatuses)callbackEnd.Status);
            return callbackEnd;
        }
        
        
    }
    
}
