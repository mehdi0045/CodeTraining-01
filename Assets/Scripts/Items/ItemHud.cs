using UnityEngine;

[CreateAssetMenu(menuName = "New ItemHud" , fileName = "ItemHud")]
public class ItemHud : ScriptableObject
{
    public string Id;
    public string Name;
    public string Description;
    public Sprite Icon;
}
