using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "SO/Buildings")]
public class SO_Buildings : ScriptableObject
{
    public Transform building;
    public string buildingName;
    public Sprite buildingSprite;
    public int cost;
}
