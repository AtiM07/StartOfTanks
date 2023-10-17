using System;

/// <summary>
/// ячейка глобальной карты
/// </summary>
[Serializable]
public class Cell
{
    public CellType Type;
    public int X;
    public int Y;
}