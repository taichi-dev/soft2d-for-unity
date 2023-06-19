using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Inventory
{
    public InventoryType Type;
    public int InventoryNum;
}

public enum InventoryType
{
    Triangle,
    Square,
    Heater,
}

[CreateAssetMenu(fileName = "LevelData",menuName = "ScriptableObject/LevelData",order=1)]
public class LevelData : ScriptableObject
{
    public List<Inventory> Inventories;
    public string levelName;
    public int volumeGoal = 100;
}
