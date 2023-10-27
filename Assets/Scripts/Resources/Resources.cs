using System;

/// <summary>
/// Перечисление ресурсов игрока
/// </summary>
[Serializable]
public class Resources
{
    /// <summary>
    /// Нефть
    /// </summary>
    public int Oil = 0;

    /// <summary>
    /// Уголь
    /// </summary>
    public int Coal = 0;

    /// <summary>
    /// Руда
    /// </summary>
    public int Ore = 0;

    /// <summary>
    /// Известняк
    /// </summary>
    public int Limestone = 0;

    /// <summary>
    /// Сера
    /// </summary>
    public int Sulphur = 0;

    /// <summary>
    /// Вода
    /// </summary>
    public int Water = 0;

    /// <summary>
    /// Деньги
    /// </summary>
    public int Money = 0;

    /// <summary>
    /// Энергия
    /// </summary>
    public int Energy = 0;

    /// <summary>
    /// Детали заводов
    /// </summary>
    public int Details = 0;

    /// <summary>
    /// Сталь
    /// </summary>
    public int Steel = 0;

    /// <summary>
    /// Игровая валюта
    /// </summary>
    public int Currency = 0;

    /// <summary>
    /// Пластик
    /// </summary>
    public int Plastic = 0;

    /// <summary>
    /// Резина
    /// </summary>
    public int Rubber = 0;

    public static Resources operator +(Resources a, Resources b)
    {
        var resources = new Resources();

        var fields = typeof(Resources).GetFields();
        foreach (var prop in fields)
        {
            var valueA = (int) prop.GetValue(a);
            var valueB = (int) prop.GetValue(b);
            prop.SetValue(resources, valueA + valueB);
        }

        return resources;
    }
    
    public static Resources operator -(Resources a, Resources b)
    {
        var resources = new Resources();

        var fields = typeof(Resources).GetFields();
        foreach (var prop in fields)
        {
            var valueA = (int) prop.GetValue(a);
            var valueB = (int) prop.GetValue(b);
            prop.SetValue(resources, valueA - valueB);
        }

        return resources;
    }
    
    /// <summary>
    /// Сравнение происходит без учета нулевых значений правого значения
    /// </summary>
    /// <param name="a">Ресурсы игрока</param>
    /// <param name="b">Ресурсы для сравнения</param>
    public static bool operator <(Resources a, Resources b)
    {
        var fields = typeof(Resources).GetFields();
        foreach (var prop in fields)
        {
            var current = (int)prop.GetValue(b);
            if (current != 0)
            {
                var value = (int)prop.GetValue(a);
                if (value < current)
                    return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Сравнение происходит без учета нулевых значений правого значения
    /// </summary>
    /// <param name="a">Ресурсы игрока</param>
    /// <param name="b">Ресурсы для сравнения</param>
    public static bool operator >(Resources a, Resources b)
    {
        var fields = typeof(Resources).GetFields();
        foreach (var prop in fields)
        {
            var current = (int)prop.GetValue(b);
            if (current != 0)
            {
                var value = (int)prop.GetValue(a);
                if (value > current)
                    return false;
            }
        }
        return true;
    }
}