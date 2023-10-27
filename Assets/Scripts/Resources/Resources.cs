using System;

/// <summary>
/// ������������ �������� ������
/// </summary>
[Serializable]
public class Resources
{
    /// <summary>
    /// �����
    /// </summary>
    public int Oil = 0;

    /// <summary>
    /// �����
    /// </summary>
    public int Coal = 0;

    /// <summary>
    /// ����
    /// </summary>
    public int Ore = 0;

    /// <summary>
    /// ���������
    /// </summary>
    public int Limestone = 0;

    /// <summary>
    /// ����
    /// </summary>
    public int Sulphur = 0;

    /// <summary>
    /// ����
    /// </summary>
    public int Water = 0;

    /// <summary>
    /// ������
    /// </summary>
    public int Money = 0;

    /// <summary>
    /// �������
    /// </summary>
    public int Energy = 0;

    /// <summary>
    /// ������ �������
    /// </summary>
    public int Details = 0;

    /// <summary>
    /// �����
    /// </summary>
    public int Steel = 0;

    /// <summary>
    /// ������� ������
    /// </summary>
    public int Currency = 0;

    /// <summary>
    /// �������
    /// </summary>
    public int Plastic = 0;

    /// <summary>
    /// ������
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