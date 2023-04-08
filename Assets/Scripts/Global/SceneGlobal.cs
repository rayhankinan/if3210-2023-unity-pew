public class SceneGlobal
{
    public static string value;
    
    public static void LoadFromFile()
    {
        value = DataSaver.LoadData<string>("scene");
    }
    
    public static void SaveToFile()
    {
        DataSaver.SaveData(value, "scene");
    }
}