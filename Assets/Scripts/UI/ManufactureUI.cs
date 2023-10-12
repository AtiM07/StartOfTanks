using System;
using UnityEngine;
using UnityEngine.UI;

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
