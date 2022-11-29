using UnityEngine;

[CreateAssetMenu(menuName = "New WordGameItem" , fileName = "WordGameItem")]
public class GameItem : ScriptableObject
{
    public string Id;

    public string Name;

    public string Type;
}
