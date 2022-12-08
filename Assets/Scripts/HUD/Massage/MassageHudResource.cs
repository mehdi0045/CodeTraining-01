using System;
using UnityEngine;

public class MassageHudResource : MonoBehaviour
{
    public MassageHudHolder massageHudHolder;
    
    public bool FindItem(string id , out MassageHud massageHud)
    {
        var find = Array.Find(massageHudHolder.MassageInfos, i => i.Id == id);
        var massageObject = Resources.Load<MassageHud>(find.ResourcePath);
        if (massageObject == null)
        {
            massageHud = null;
            return false;
        }
        
        massageHud = massageObject;
        return true;
    }
}
