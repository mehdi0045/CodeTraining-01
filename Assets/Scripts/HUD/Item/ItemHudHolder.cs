using UnityEngine;

namespace HUD.Item
{
    [CreateAssetMenu(menuName = "New ItemHud Holder" , fileName = "ItemHolder")]
    public class ItemHudHolder : ScriptableObject
    {
        public ItemHudInfo[] ItemInfos;
    }
}
