using System;
using System.Collections.Generic;

[Serializable]
public class StateData
{
    public string playerName;
    public int volume = 100;
    
    public SaveEntry[] saveEntries;
    public List<ScoreEntry> scoreEntries;
}