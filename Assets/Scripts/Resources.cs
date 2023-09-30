using System;

[Serializable]
public struct Resources
{
    /// <summary>
    /// �����
    /// </summary>
    public int Oil;

    /// <summary>
    /// �����
    /// </summary>
    public int Coal;

    /// <summary>
    /// ����
    /// </summary>
    public int Ore;

    /// <summary>
    /// ���������
    /// </summary>
    public int Limestone;

    /// <summary>
    /// ����
    /// </summary>
    public int Sulphur;

    /// <summary>
    /// ����
    /// </summary>
    public int Water;

    /// <summary>
    /// ������
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