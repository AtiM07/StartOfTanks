using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���������������� ��������� ����������� ����
/// </summary>
public class PopUpUI : MonoBehaviour
{
    [SerializeField] private Button closeButton;

    void Start()
    {
        closeButton.onClick.AddListener(() => Destroy(gameObject));
    }
}