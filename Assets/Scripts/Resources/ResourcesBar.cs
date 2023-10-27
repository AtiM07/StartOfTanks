using TMPro;
using UnityEngine;

/// <summary>
/// ����������� ��������
/// </summary>
public class ResourcesBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] valueGroup;

    public void UpdateView(Resources resources)
    {
        foreach (var element in valueGroup)
        {
            element.text = resources.GetValue(element.name).ToString();
        }
    }
}