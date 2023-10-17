using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Пользовательский интерфейс всплывающих окон
/// </summary>
public class PopUpUI : MonoBehaviour
{
    [SerializeField] private Button closeButton;

    void Start()
    {
        closeButton.onClick.AddListener(() => Destroy(gameObject));
    }
}