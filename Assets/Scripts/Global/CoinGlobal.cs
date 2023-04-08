using System;

public class CoinGlobal
{
    public static int value;

    public static void LoadFromFile()
    {
        value = DataSaver.LoadData<int>("coin");
    }
    
    public static void SaveToFile()
    {
        DataSaver.SaveData(value, "coin");
    }
}