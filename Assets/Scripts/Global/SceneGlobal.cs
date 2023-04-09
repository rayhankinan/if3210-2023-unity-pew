public class SceneGlobal
{
    private static string _value;
    
    public static void LoadFromFile()
    {
        _value = DataSaver.LoadData<string>("scene");
    }
    
    public static void SaveToFile()
    {
        DataSaver.SaveData(_value, "scene");
    }

    public static string GetCurrentValue()
    {
        return _value;
    }
    
    public static void ChangeScene(string value)
    {
        _value = value;
    }
}