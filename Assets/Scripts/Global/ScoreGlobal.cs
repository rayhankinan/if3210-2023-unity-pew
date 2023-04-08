public class ScoreGlobal
{
    public static int value;
    
    public static void LoadFromFile()
    {
        value = DataSaver.LoadData<int>("score");
    }
    
    public static void SaveToFile()
    {
        DataSaver.SaveData(value, "score");
    }
}