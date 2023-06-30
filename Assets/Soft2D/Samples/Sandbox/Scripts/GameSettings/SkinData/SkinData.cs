using UnityEngine;


[CreateAssetMenu(fileName = "SkinData",menuName = "ScriptableObject/SkinData",order = 2)]
public class SkinData : ScriptableObject
{
    [Header("Inventory Sprite")]
    [Tooltip("Square Type Sprite")]
    public Sprite Square;
    [Tooltip("Triangle Type Sprite")]
    public Sprite Triangle;
    [Tooltip("Heater Type Sprite")] 
    public Sprite Heater;

}
