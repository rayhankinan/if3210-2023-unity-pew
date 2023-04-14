using System;
using System.Collections.Generic;

public class CurrentStateData
{
    private static StateData _currentStateData;
    private static GameData _currentGameData;

    public static void LoadStateData()
    {
        _currentStateData = DataSaver.LoadData<StateData>("current_state") ?? new StateData();
        _currentStateData.saveEntries ??= new List<SaveEntry>();
        _currentStateData.scoreEntries ??= new List<ScoreEntry>();

        _currentGameData.playerName = _currentStateData.playerName;
        _currentGameData.scene = "level_01";
        _currentGameData.coin = 0;
        _currentGameData.playTime = 0;
    }

    public static void SaveStateData()
    {
        DataSaver.SaveData(_currentStateData, "current_state");
    }

    public static string GetGlobalPlayerName()
    {
        return _currentStateData.playerName;
    }

    public static void ChangeGlobalPlayerName(string name)
    {
        _currentStateData.playerName = name;
    }

    public static int GetVolume()
    {
        return _currentStateData.volume;
    }

    public static void ChangeVolume(int volumeDiff)
    {
        _currentStateData.volume += volumeDiff;
        _currentStateData.volume = Math.Min(Math.Max(_currentStateData.volume, 0), 100);
    }

    public static List<SaveEntry> GetSaveEntries()
    {
        return _currentStateData.saveEntries;
    }

    public static List<ScoreEntry> GetScoreEntries()
    {
        _currentStateData.scoreEntries.Sort((s1, s2) => s1.playTime.CompareTo(s2.playTime));
        return _currentStateData.scoreEntries;
    }

    public static bool LoadGameData(int index)
    {
        if (_currentStateData.saveEntries.Count < index)
        {
            return false;
        }
        
        var loadedSaveEntry = _currentStateData.saveEntries[index];
        _currentGameData.playerName = loadedSaveEntry.playerName;
        _currentGameData.scene = loadedSaveEntry.scene;
        _currentGameData.coin = loadedSaveEntry.coin;
        _currentGameData.playTime = loadedSaveEntry.playTime;
        
        return true;
    }

    public static void SaveGameData(string saveName, int index)
    {
        var saveEntry = new SaveEntry
        {
            saveName = saveName,
            saveDateTime = DateTime.Now,
            playerName = _currentGameData.playerName,
            playTime = _currentGameData.playTime,
            coin = _currentGameData.coin,
            scene = _currentGameData.scene
        };

        if (_currentStateData.saveEntries.Count < 3)
        {
            _currentStateData.saveEntries.Add(saveEntry);
        }
        else
        {
            _currentStateData.saveEntries[index] = saveEntry;
        }
        
        SaveStateData();
    }

    public static string GetCurrentPlayerName()
    {
        return _currentGameData.playerName;
    }

    public static int GetCurrentCoin()
    {
        return _currentGameData.coin;
    }

    public static void AddCoin(int coin)
    {
        _currentGameData.coin += coin;
    }

    public static void SubtractCoin(int coin)
    {
        if (_currentGameData.coin < coin) throw new InvalidOperationException("Coin tidak bisa lebih kecil dari 0");

        _currentGameData.coin -= coin;
    }

    public static float GetCurrentPlayTime()
    {
        return _currentGameData.playTime;
    }

    public static void AddPlayTime(float delta)
    {
        _currentGameData.playTime += delta;
    }

    public static string GetCurrentScene()
    {
        return _currentGameData.scene;
    }

    public static void ChangeScene(string scene)
    {
        _currentGameData.scene = scene;
    }
}