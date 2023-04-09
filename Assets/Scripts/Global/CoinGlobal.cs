public class CoinGlobal
{
    private static int _value;

    public static void LoadFromFile()
    {
        _value = DataSaver.LoadData<int>("coin");
    }
    
    public static void SaveToFile()
    {
        DataSaver.SaveData(_value, "coin");
    }

    public static int GetCurrentValue()
    {
        return _value;
    }

    public static void AddCoin(int value)
    {
        _value += value;
    }
}