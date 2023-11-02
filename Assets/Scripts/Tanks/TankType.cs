using System;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[Serializable]
[JsonConverter(typeof(StringEnumConverter))]
public enum TankType
{
    [Description("легкий")] Light,

    [Description("средний")] Medium,

    [Description("тяжелый")] Heavy,

    [Description("САУ")] SPG
}