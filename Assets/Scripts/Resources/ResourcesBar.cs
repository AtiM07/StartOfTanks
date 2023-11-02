using System.ComponentModel;
using System.Linq;
using System.Reflection;
using TMPro;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;

/// <summary>
/// Отображение ресурсов
/// </summary>
public class ResourcesBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] valueGroup;
    [SerializeField] private TextMeshProUGUI[] nameGroup;

    public void UpdateView(Resources resources)
    {
        foreach (var element in valueGroup)
        {
            element.text = resources.GetValue(element.name).ToString();
        }
    }

    public void UpdateView(Resources resources, Recipe[] recipes)
    {
        foreach (var element in valueGroup)
        {
            element.text = ""; //resources.GetValue(element.name).ToString();
        }

        foreach (var element in nameGroup)
        {
            element.text = ""; //resources.GetValue(element.name).ToString();
        }
    }

    public void UpdateView(Tank tank)
    {
        var fields = typeof(Tank).GetDeclaredFields();
        foreach (var item in valueGroup)
        {
            var field = fields.First(x => x.Name == item.name);
            var value = field.GetValue(tank);
            if (field.FieldType == typeof(bool))
            {
                item.text = Tank.BoolToString(value);
            }
            else
            {
                var attr = field.GetCustomAttribute<DescriptionAttribute>();

                if (attr is not null)
                    attr = field.FieldType.GetField(value.ToString()).GetCustomAttribute<DescriptionAttribute>();

                item.text = attr is null ? value.ToString() : attr.Description;
            }
        }
    }
}