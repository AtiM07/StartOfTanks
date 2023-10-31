using System;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[Serializable]
[JsonConverter(typeof(StringEnumConverter))]
public enum GunType
{
    [Description("������ ������ �������")] Min,

    [Description("������ �������� �������")]
    Medium,

    [Description("������ �������� �������")]
    Max
}