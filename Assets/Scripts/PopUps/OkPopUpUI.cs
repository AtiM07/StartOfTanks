using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Пользовательский интерфейс окна подтверждения
/// </summary>
public class OkPopUpUI : MonoBehaviour
{
    [SerializeField] public Button okButton;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private TextMeshProUGUI titleText;

    private void Start()
    {
        okButton.onClick.AddListener(() => Destroy(gameObject));
    }

    /// <summary>
    /// Передать значение результата
    /// </summary>
    /// <param name="result"></param>
    public void SetResultText(string result) //to do: сделать интерфейсом
    {
        resultText.text = result;
    }

    /// <summary>
    /// Передать значение заголовка
    /// </summary>
    /// <param name="title"></param>
    public void SetTitleText(string title) //to do: сделать интерфейсом
    {
        titleText.text = title;
    }
}