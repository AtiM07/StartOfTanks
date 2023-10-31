using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;

/// <summary>
/// Перечисление ресурсов игрока
/// </summary>
[Serializable]
public class Resources
{
    #region Ресурсы

    [Tooltip("Нефть")] [Description("Нефть")]
    public int Oil = 0;

    [Tooltip("Уголь")] [Description("Уголь")]
    public int Coal = 0;

    [Tooltip("Руда")] [Description("Руда")]
    public int Ore = 0;

    [Tooltip("Известняк")] [Description("Известняк")]
    public int Limestone = 0;

    [Tooltip("Сера")] [Description("Сера")]
    public int Sulphur = 0;

    [Tooltip("Вода")] [Description("Вода")]
    public int Water = 0;

    [Tooltip("Деньги")] [Description("Деньги")]
    public int Money = 0;

    [Tooltip("Энергия")] [Description("Энергия")]
    public int Energy = 0;

    [Tooltip("Сталь")] [Description("Сталь")]
    public int Steel = 0;

    [Tooltip("Игровая валюта")] [Description("Игровая валюта")]
    public int Currency = 0;

    [Tooltip("Пластик")] [Description("Пластик")]
    public int Plastic = 0;

    [Tooltip("Резина")] [Description("Резина")]
    public int Rubber = 0;

    [Tooltip("Очищенная руда")] [Description("Очищенная руда")]
    public int RefinedOre = 0;

    [Tooltip("Цветные металлы")] [Description("Цветные металлы")]
    public int NonferrousMetal = 0;

    [Tooltip("Нитраты")] [Description("Нитраты")]
    public int Nitrates = 0;

    [Tooltip("Порох")] [Description("Порох")]
    public int Powder = 0;

    [Tooltip("Органика")] [Description("Органика")]
    public int Organic = 0;

    [Tooltip("Топливо")] [Description("Топливо")]
    public int Fuel = 0;

    [Tooltip("Детали танков")] [Description("Детали танков")]
    public int TankParts = 0;

    [Tooltip("Снаряды")] [Description("Снаряды")]
    public int Shells = 0;

    [Tooltip("Детали заводов")] [Description("Детали заводов")]
    public int Details = 0;

    [Tooltip("Газ")] [Description("Газ")] public int Monoxide = 0;

    [Tooltip("Каркас")]
    [Description("Каркас")]
    private int Part1
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("Легкая броня танка")]
    [Description("Легкая броня танка")]
    private int Part2
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("Средняя броня танка")]
    [Description("Средняя броня танка")]
    private int Part3
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("Тяжелая броня танка")]
    [Description("Тяжелая броня танка")]
    private int Part4
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("Пушка крупный калибр")]
    [Description("Пушка крупный калибр")]
    private int Part5
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("Пушка средний калибр")]
    [Description("Пушка средний калибр")]
    private int Part6
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("Скорострельная пушка")]
    [Description("Скорострельная пушка")]
    private int Part7
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("Пушка малого калибра")]
    [Description("Пушка малого калибра")]
    private int Part8
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("Малая радиостанция")]
    [Description("Малая радиостанция")]
    private int Part9
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("Большая радиостанция")]
    [Description("Большая радиостанция")]
    private int Part10
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("Модуль маскировки")]
    [Description("Модуль маскировки")]
    private int Part11
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("Устройство разведки")]
    [Description("Устройство разведки")]
    private int Part12
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("Снаряды крупного калибра")]
    [Description("Снаряды крупного калибра")]
    private int Shell1
    {
        get => Shells;
        set => Shells = value;
    }

    [Tooltip("Снаряды среднего калибра")]
    [Description("Снаряды среднего калибра")]
    private int Shell2
    {
        get => Shells;
        set => Shells = value;
    }

    [Tooltip("Снаряды малого калибра")]
    [Description("Снаряды малого калибра")]
    private int Shell3

    {
        get => Shells;
        set => Shells = value;
    }

    #endregion

    public MemberInfo[] GetProperties() =>
        typeof(Resources).GetFields().Cast<MemberInfo>()
            .Union((typeof(Resources).GetDeclaredProperties().Cast<MemberInfo>())).ToArray();

    public MemberInfo GetProperty(string name) =>
        (MemberInfo)typeof(Resources).GetField(name) ?? typeof(Resources).GetProperty(name);

    public int GetValue(string name) => GetValue(GetProperty(name));

    public int GetValue(MemberInfo member) => member switch
    {
        FieldInfo field => (int)field.GetValue(this),
        PropertyInfo property => (int)property.GetValue(this),
        _ => 0
    };

    public void SetValue(MemberInfo member, int summand)
    {
        switch (member)
        {
            case FieldInfo field:
                var value = GetValue(member);
                field.SetValue(this, value + summand);
                break;
            case PropertyInfo property:
                var value1 = GetValue(member);
                property.SetValue(this, value1 + summand);
                break;
        }
    }

    public MemberInfo GetFieldByTranslate(string translate) => GetProperties()
        .First(x => x.GetCustomAttribute<DescriptionAttribute>()?.Description == translate);

    public int GetValueByTranslate(string translate) => GetValue(GetFieldByTranslate(translate));

    public void SetValue(string translate, int summand) => SetValue(GetFieldByTranslate(translate), summand);

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

    public static Resources operator -(Resources a, Ingredient b)
    {
        a.SetValue(b.Name, -b.Count);
        return a;
    }

    public static bool operator <(Resources a, Ingredient[] b)
    {
        foreach (var ingredient in b)
        {
            var field = a.GetValueByTranslate(ingredient.Name);
            if (field > ingredient.Count)
                return false;
        }

        return true;
    }

    public static bool operator >(Resources a, Ingredient[] b)
    {
        foreach (var ingredient in b)
        {
            var field = a.GetValueByTranslate(ingredient.Name);
            if (field < ingredient.Count)
                return false;
        }

        return true;
    }
}