using System;

[Serializable]
public struct SaveEntry
{
    public string saveName;
    public SerializableDateTime saveDateTime;
    public string playerName;
    public int coin;
    public float score;
    public int playTime;
    public string scene;
}