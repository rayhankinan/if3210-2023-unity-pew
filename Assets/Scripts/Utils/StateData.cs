using System;
using System.Collections.Generic;

[Serializable]
public class StateData
{
    public string playerName;
    public int volume;
    
    public List<SaveEntry> saveEntries;
    public List<ScoreEntry> scoreEntries;
}