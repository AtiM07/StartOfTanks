using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// Переключатель выбора из нескольких элементов
/// </summary>
public class Selector : MonoBehaviour
{
    public bool isActive;
    [SerializeField] private Image selector;
    [SerializeField] public UnityEvent<bool> onActiveChange;

    private void Start()
    {
        onActiveChange.AddListener(ChangeActive);
        onActiveChange.Invoke(isActive);
    }

    private void ChangeActive(bool value)
    {
        isActive = value;
        selector.enabled = isActive;
    }
}