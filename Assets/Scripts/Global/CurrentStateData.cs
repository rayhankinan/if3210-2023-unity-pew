using System;

public class CurrentStateData
{
    private static StateData _currentStateData;
    private static GameData _currentGameData;

    public static void LoadData()
    {
        _currentStateData = DataSaver.LoadData<StateData>("current_state");
        
        _currentGameData.playerName = _currentStateData.playerName;
        _currentGameData.scene = "level_01";
        _currentGameData.coin = 0;
        _currentGameData.score = 0;
        _currentGameData.playTime = 0;
    }

    public static void SaveData()
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

    public static void LoadGameData(int index)
    {
        var loadedSaveEntry = _currentStateData.saveEntries[index];
        _currentGameData.playerName = loadedSaveEntry.playerName;
        _currentGameData.scene = loadedSaveEntry.scene;
        _currentGameData.coin = loadedSaveEntry.coin;
        _currentGameData.score = loadedSaveEntry.score;
        _currentGameData.playTime = loadedSaveEntry.playTime;
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

    public static float GetCurrentScore()
    {
        return _currentGameData.score;
    }

    public static void AddScore(float score)
    {
        _currentGameData.score += score;
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