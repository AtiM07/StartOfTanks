using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OkPopUpUI : MonoBehaviour
{
    [SerializeField] public Button okButton;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private TextMeshProUGUI titleText;

    private void Start()
    {
        okButton.onClick.AddListener(() => Destroy(gameObject));
        resultText.text = "0";
        titleText.text = "Результат выполнения:";
    }

    public void SetResultText(string result)
    {
        resultText.text = result;
    }

    public void SetTitleText(string title)
    {
        titleText.text = title;
    }
}