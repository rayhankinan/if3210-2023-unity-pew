using System;

[Serializable]
public struct SerializableDateTime {
    public long value;
    
    public static implicit operator DateTime(SerializableDateTime sdt) 
    {
        return DateTime.FromFileTime(sdt.value);
    }
    
    public static implicit operator SerializableDateTime(DateTime dt) 
    {
        var sdt = new SerializableDateTime
        {
            value = dt.ToFileTime()
        };
        return sdt;
    }

    public override string ToString()
    {
        return DateTime.FromFileTimeUtc(value).ToString("u");
    }
}