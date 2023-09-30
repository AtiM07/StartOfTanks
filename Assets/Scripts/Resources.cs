using System;

[Serializable]
public struct Resources
{
    /// <summary>
    /// Нефть
    /// </summary>
    public int Oil;

    /// <summary>
    /// Уголь
    /// </summary>
    public int Coal;

    /// <summary>
    /// Руда
    /// </summary>
    public int Ore;

    /// <summary>
    /// Известняк
    /// </summary>
    public int Limestone;

    /// <summary>
    /// Сера
    /// </summary>
    public int Sulphur;

    /// <summary>
    /// Вода
    /// </summary>
    public int Water;

    /// <summary>
    /// Деньги
    /// </summary>
    public int Money;

    public Resources(int oil, int coal, int ore, int limestone, int sulphur, int water, int money)
    {
        Oil = oil;
        Coal = coal;
        Ore = ore;
        Limestone = limestone;
        Sulphur = sulphur;
        Water = water;
        Money = money;
    }
}