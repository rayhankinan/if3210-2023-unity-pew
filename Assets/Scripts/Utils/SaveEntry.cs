using System;
using System.Collections.Generic;

[Serializable]
public struct SaveEntry
{
    public string saveName;
    public SerializableDateTime saveDateTime;
    public string playerName;
    public int coin;
    public float playTime;
    public string scene;
    public List<int> pets;
    public int currentWeapon;
    public bool[] weapons;
}