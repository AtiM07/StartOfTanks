using System;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[Serializable]
[JsonConverter(typeof(StringEnumConverter))]
public enum GunType
{
    [Description("Орудие малого калибра")] Min,

    [Description("Орудие среднего калибра")]
    Medium,

    [Description("Орудие крупного калибра")]
    Max
}