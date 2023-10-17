using System;

/// <summary>
/// Перечисление ресурсов игрока
/// </summary>
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
}