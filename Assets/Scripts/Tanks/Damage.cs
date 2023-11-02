using System;

[Serializable]
public class Damage
{
    public int Min = 0;
    public int Max = 0;

    public override string ToString()
    {
        return $"{Min}-{Max}";
    }
}