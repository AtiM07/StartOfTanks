using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���������������� ��������� ���� ����� �������� 
/// </summary>
public class ReconnaissancePopUpUI : MonoBehaviour
{
    [SerializeField] private Button reconnaissanceButton;

    [SerializeField] private GameObject okPopUpWindow;
    private void Start()
    {
        reconnaissanceButton.onClick.AddListener(GoExplore);
    }
    
    private void GoExplore() //��������� �� ��������
    {
        var okObject = Instantiate(okPopUpWindow, transform.parent);
        var script = okObject.GetComponent<OkPopUpUI>();
        script.SetTitleText("��������� ��������");
        script.SetResultText("0");
        Destroy(gameObject);
    }
}
