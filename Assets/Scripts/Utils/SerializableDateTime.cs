using System;

[Serializable]
public struct SerializableDateTime {
    public long value;
    
    public static implicit operator DateTime(SerializableDateTime sdt) 
    {
        return DateTime.FromFileTimeUtc(sdt.value);
    }
    
    public static implicit operator SerializableDateTime(DateTime dt) 
    {
        SerializableDateTime sdt = new SerializableDateTime();
        sdt.value = dt.ToFileTimeUtc();
        return sdt;
    }

    public string ToString()
    {
        return DateTime.FromFileTimeUtc(value).ToString("u");
    }
}