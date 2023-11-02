using System;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[Serializable]
[JsonConverter(typeof(StringEnumConverter))]
public enum TankType
{
    [Description("������")] Light,

    [Description("�������")] Medium,

    [Description("�������")] Heavy,

    [Description("���")] SPG
}