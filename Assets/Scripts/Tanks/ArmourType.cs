using System;
using System.ComponentModel;

[Serializable]
public enum ArmourType
{
    [Description("Легкая броня")] Min,

    [Description("Средняя броня")] Medium,

    [Description("Тяжелая  броня")] Max,
    [Description("Броня отсутствует")] None
}