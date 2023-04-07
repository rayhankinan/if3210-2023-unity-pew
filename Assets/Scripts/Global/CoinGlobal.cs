using System;

public class CoinGlobal
{
    public static int value = 0;

    public static void LoadFromFile()
    {
        try
        {
            value = DataSaver.LoadData<int>("coin");
        }
        catch (Exception)
        {
            value = 0;
        }
    }
    
    public static void SaveToFile()
    {
        DataSaver.SaveData(value, "coin");
    }
}