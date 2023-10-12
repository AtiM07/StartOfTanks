using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OkPopUpUI : MonoBehaviour
{
    [SerializeField] private Button okButton;
    [SerializeField] private TextMeshProUGUI titleText;

    private void Start()
    {
        okButton.onClick.AddListener(() => Destroy(gameObject));
    }

    public void SetResultText(string result)
    {
        titleText.text = result;
    }
}