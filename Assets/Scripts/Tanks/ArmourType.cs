using System;
using System.ComponentModel;

[Serializable]
public enum ArmourType
{
    [Description("������ �����")] Min,

    [Description("������� �����")] Medium,

    [Description("�������  �����")] Max,
    [Description("����� �����������")] None
}