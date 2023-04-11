using System;

public class CurrentStateData
{
    private static StateData _currentStateData;

    public static void LoadData()
    {
        _currentStateData = DataSaver.LoadData<StateData>("current_state");
    }

    public static void SaveData()
    {
        DataSaver.SaveData(_currentStateData, "current_state");
    }

    public static int GetCurrentCoin()
    {
        return _currentStateData.coin;
    }

    public static void AddCoin(int coin)
    {
        _currentStateData.coin += coin;
    }

    public static void SubtractCoin(int coin)
    {
        if (_currentStateData.coin < coin) throw new InvalidOperationException("Coin tidak bisa lebih kecil dari 0");

        _currentStateData.coin -= coin;
    }

    public static float GetCurrentScore()
    {
        return _currentStateData.score;
    }

    public static void AddScore(float score)
    {
        _currentStateData.score += score;
    }

    public static string GetCurrentScene()
    {
        return _currentStateData.scene;
    }

    public static void ChangeScene(string scene)
    {
        _currentStateData.scene = scene;
    }
}