using JetBrains.Annotations;
using TMPro;
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
}