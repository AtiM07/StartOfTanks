using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Пользовательский интерфейс производства
/// </summary>
public class ManufactureUI : MonoBehaviour
{
    [SerializeField] private Button CreateButton;

    private TankJsonParser _tankJsonParser;

    private void Start()
    {
        _tankJsonParser = Camera.main.GetComponent<TankJsonParser>();


        CreateButton.onClick.AddListener(ApplyCharacteristics);
    }

    private void ApplyCharacteristics()
    {
        Debug.Log("Характеристики применены");
    }
}