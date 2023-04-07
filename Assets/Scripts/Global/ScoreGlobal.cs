using System;

public class ScoreGlobal
{
    public static int value = 0;
    
    public static void LoadFromFile()
    {
        try
        {
            value = DataSaver.LoadData<int>("score");
        }
        catch (Exception)
        {
            value = 0;
        }
    }
    
    public static void SaveToFile()
    {
        DataSaver.SaveData(value, "score");
    }
}