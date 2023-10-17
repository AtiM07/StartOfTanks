using TMPro;
using UnityEngine;

/// <summary>
/// ���������������� ��������� ��������������� ����
/// </summary>
public class InfoPopUpUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI infoText;

    /// <summary>
    /// ������ ����������
    /// </summary>
    /// <param name="info"></param>
    public void SetInfoText(string info)
    {
        infoText.text = info;
    }
}
