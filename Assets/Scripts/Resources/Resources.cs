using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

/// <summary>
/// ������������ �������� ������
/// </summary>
[Serializable]
public class Resources
{
    #region �������

    [Description("�����")] public int Oil = 0;

    [Description("�����")] public int Coal = 0;

    [Description("����")] public int Ore = 0;

    [Description("���������")] public int Limestone = 0;

    [Description("����")] public int Sulphur = 0;

    [Description("����")] public int Water = 0;

    [Description("������")] public int Money = 0;

    [Description("�������")] public int Energy = 0;

    [Description("�����")] public int Steel = 0;

    [Description("������� ������")] public int Currency = 0;

    [Description("�������")] public int Plastic = 0;

    [Description("������")] public int Rubber = 0;

    [Description("��������� ����")] public int RefinedOre = 0;

    [Description("������� �������")] public int NonferrousMetal = 0;

    [Description("�������")] public int Nitrates = 0;

    [Description("�����")] public int Powder = 0;

    [Description("��������")] public int Organic = 0;

    [Description("�������")] public int Fuel = 0;

    [Description("������ ������")] public int TankParts = 0;

    [Description("�������")] public int Shells = 0;

    [Description("������ �������")] public int Details = 0;

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
    /// ��������� ���������� ��� ����� ������� �������� ������� ��������
    /// </summary>
    /// <param name="a">������� ������</param>
    /// <param name="b">������� ��� ���������</param>
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
    /// ��������� ���������� ��� ����� ������� �������� ������� ��������
    /// </summary>
    /// <param name="a">������� ������</param>
    /// <param name="b">������� ��� ���������</param>
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