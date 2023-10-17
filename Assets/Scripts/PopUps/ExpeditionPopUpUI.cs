using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���������������� ��������� ���� ����������
/// </summary>
public class ExpeditionPopUpUI : MonoBehaviour
{
    [SerializeField] private Button resoursesButton;

    [SerializeField] private GameObject okPopUpWindow;
    private void Start()
    {
        resoursesButton.onClick.AddListener(GoExplore);
    }
    
    private void GoExplore() //��������� � ����������
    {
        var okObject = Instantiate(okPopUpWindow, transform.parent);
        var script = okObject.GetComponent<OkPopUpUI>();
        script.SetTitleText("�������� ������ ��������");
        script.SetResultText("0");
        Destroy(gameObject);
    }
}
