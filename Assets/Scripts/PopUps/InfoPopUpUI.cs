using TMPro;
using UnityEngine;

/// <summary>
/// Пользовательский интерфейс информационного окна
/// </summary>
public class InfoPopUpUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI infoText;

    /// <summary>
    /// Задать информацию
    /// </summary>
    /// <param name="info"></param>
    public void SetInfoText(string info)
    {
        infoText.text = info;
    }
}
