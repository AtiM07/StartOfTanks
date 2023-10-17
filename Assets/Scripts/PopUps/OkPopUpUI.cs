using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���������������� ��������� ���� �������������
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
    /// �������� �������� ����������
    /// </summary>
    /// <param name="result"></param>
    public void SetResultText(string result) //to do: ������� �����������
    {
        resultText.text = result;
    }

    /// <summary>
    /// �������� �������� ���������
    /// </summary>
    /// <param name="title"></param>
    public void SetTitleText(string title) //to do: ������� �����������
    {
        titleText.text = title;
    }
}