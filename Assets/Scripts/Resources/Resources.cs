using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

/// <summary>
/// Перечисление ресурсов игрока
/// </summary>
[Serializable]
public class Resources
{
    #region Ресурсы

    [Description("Нефть")] public int Oil = 0;

    [Description("Уголь")] public int Coal = 0;

    [Description("Руда")] public int Ore = 0;

    [Description("Известняк")] public int Limestone = 0;

    [Description("Сера")] public int Sulphur = 0;

    [Description("Вода")] public int Water = 0;

    [Description("Деньги")] public int Money = 0;

    [Description("Энергия")] public int Energy = 0;

    [Description("Сталь")] public int Steel = 0;

    [Description("Игровая валюта")] public int Currency = 0;

    [Description("Пластик")] public int Plastic = 0;

    [Description("Резина")] public int Rubber = 0;

    [Description("Очищенная руда")] public int RefinedOre = 0;

    [Description("Цветные металлы")] public int NonferrousMetal = 0;

    [Description("Нитраты")] public int Nitrates = 0;

    [Description("Порох")] public int Powder = 0;

    [Description("Органика")] public int Organic = 0;

    [Description("Топливо")] public int Fuel = 0;

    [Description("Детали танков")] public int TankParts = 0;

    [Description("Снаряды")] public int Shells = 0;

    [Description("Детали заводов")] public int Details = 0;

    #endregion

    public int GetValue(string name) => (int)typeof(Resources).GetField(name).GetValue(this);

    public int GetValueByTranslate(string translate) => (int)typeof(Resources).GetFields()
        .First(x => x.GetCustomAttribute<DescriptionAttribute>().Description == translate)
        .GetValue(this);

    public static Resources operator +(Resources a, Resources b)
    {
        var resources = new Resources();

        var fields = typeof(Resources).GetFields();
        foreach (var prop in fields)
        {
            var valueA = (int)prop.GetValue(a);
            var valueB = (int)prop.GetValue(b);
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
            var valueA = (int)prop.GetValue(a);
            var valueB = (int)prop.GetValue(b);
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