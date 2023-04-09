public class ScoreGlobal
{
    private static int _value;
    
    public static void LoadFromFile()
    {
        _value = DataSaver.LoadData<int>("score");
    }
    
    public static void SaveToFile()
    {
        DataSaver.SaveData(_value, "score");
    }
    
    public static int GetCurrentValue()
    {
        return _value;
    }

    public static void AddScore(int value)
    {
        _value += value;
    }
}