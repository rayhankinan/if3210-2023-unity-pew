public class CurrentIndexData
{
    private static int _index;

    public static void SetIndex(int index)
    {
        _index = index;
    }

    public static int GetIndex()
    {
        return _index;
    }
}