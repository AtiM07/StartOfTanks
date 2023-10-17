using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Пользовательский интерфейс производства
/// </summary>
public class ManufactureUI : MonoBehaviour
{
    [SerializeField] private Button CreateButton;

    private void Start()
    {
        CreateButton.onClick.AddListener(ApplyCharacteristics);
    }

    private void ApplyCharacteristics()
    {
        Debug.Log("Характеристики применены");
    }
}
