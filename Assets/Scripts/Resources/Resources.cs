using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;

/// <summary>
/// ������������ �������� ������
/// </summary>
[Serializable]
public class Resources
{
    #region �������

    [Tooltip("�����")] [Description("�����")]
    public int Oil = 0;

    [Tooltip("�����")] [Description("�����")]
    public int Coal = 0;

    [Tooltip("����")] [Description("����")]
    public int Ore = 0;

    [Tooltip("���������")] [Description("���������")]
    public int Limestone = 0;

    [Tooltip("����")] [Description("����")]
    public int Sulphur = 0;

    [Tooltip("����")] [Description("����")]
    public int Water = 0;

    [Tooltip("������")] [Description("������")]
    public int Money = 0;

    [Tooltip("�������")] [Description("�������")]
    public int Energy = 0;

    [Tooltip("�����")] [Description("�����")]
    public int Steel = 0;

    [Tooltip("������� ������")] [Description("������� ������")]
    public int Currency = 0;

    [Tooltip("�������")] [Description("�������")]
    public int Plastic = 0;

    [Tooltip("������")] [Description("������")]
    public int Rubber = 0;

    [Tooltip("��������� ����")] [Description("��������� ����")]
    public int RefinedOre = 0;

    [Tooltip("������� �������")] [Description("������� �������")]
    public int NonferrousMetal = 0;

    [Tooltip("�������")] [Description("�������")]
    public int Nitrates = 0;

    [Tooltip("�����")] [Description("�����")]
    public int Powder = 0;

    [Tooltip("��������")] [Description("��������")]
    public int Organic = 0;

    [Tooltip("�������")] [Description("�������")]
    public int Fuel = 0;

    [Tooltip("������ ������")] [Description("������ ������")]
    public int TankParts = 0;

    [Tooltip("�������")] [Description("�������")]
    public int Shells = 0;

    [Tooltip("������ �������")] [Description("������ �������")]
    public int Details = 0;

    [Tooltip("���")] [Description("���")] public int Monoxide = 0;

    [Tooltip("������")]
    [Description("������")]
    private int Part1
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("������ ����� �����")]
    [Description("������ ����� �����")]
    private int Part2
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("������� ����� �����")]
    [Description("������� ����� �����")]
    private int Part3
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("������� ����� �����")]
    [Description("������� ����� �����")]
    private int Part4
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("����� ������� ������")]
    [Description("����� ������� ������")]
    private int Part5
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("����� ������� ������")]
    [Description("����� ������� ������")]
    private int Part6
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("�������������� �����")]
    [Description("�������������� �����")]
    private int Part7
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("����� ������ �������")]
    [Description("����� ������ �������")]
    private int Part8
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("����� ������������")]
    [Description("����� ������������")]
    private int Part9
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("������� ������������")]
    [Description("������� ������������")]
    private int Part10
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("������ ����������")]
    [Description("������ ����������")]
    private int Part11
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("���������� ��������")]
    [Description("���������� ��������")]
    private int Part12
    {
        get => TankParts;
        set => TankParts = value;
    }

    [Tooltip("������� �������� �������")]
    [Description("������� �������� �������")]
    private int Shell1
    {
        get => Shells;
        set => Shells = value;
    }

    [Tooltip("������� �������� �������")]
    [Description("������� �������� �������")]
    private int Shell2
    {
        get => Shells;
        set => Shells = value;
    }

    [Tooltip("������� ������ �������")]
    [Description("������� ������ �������")]
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