using System.Collections.Generic;
using System.Threading.Tasks;
using Action.Base;
using Action.Interface;
using Enums.Statuses;
using UnityEngine;

public class ActionAnimationSequence : IActionSequence
{
    public ActionAnimationSequence(Animator animator)
    {
        _animator = animator;
        Id = "02";
        Name = "AnimationChanger";
    }

    public string Id { get; set; }
    
    public string Name { get; set; }
    
    private Animator _animator;

    public async Task<IInteractionCallBack> ActionStep(IActionArgs iArgs, Dictionary<string, object> customData)
    {
        var callbackStart = new BaseInteractionCallback((int) EnumActionStatuses.ActionStart);
        Debug.Log((EnumActionStatuses)callbackStart.Status);
        
        _animator.SetInteger("State" , 2);
        await Task.Delay(1000);
        _animator.SetInteger("State" , 0);
        
        
        
        var callbackEnd = new BaseInteractionCallback((int) EnumActionStatuses.ActionEnd);
        Debug.Log((EnumActionStatuses)callbackEnd.Status);
        return callbackEnd;
    }
}
