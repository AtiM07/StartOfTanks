using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���������������� ��������� ������
/// </summary>
public class HangarUI : MonoBehaviour
{
    [SerializeField] private GameObject characteristics;
    [SerializeField] private Button backButton;
    [SerializeField] private GameObject infoWindow;

    private GameObject[] _slots;

    private void Start()
    {
        backButton.onClick.AddListener(() =>
        {
            if (true) //�������� �� ������������ ������
            {
                StartCoroutine(CloseHangar());
            }
        });
    }

    public void AddInSlot()
    {
        Debug.Log("���������� �� ����");
    }
    
    public void DeleteInSlot()
    {
        Debug.Log("�������� �� �����");
        
    }

    private IEnumerator CloseHangar() //����� �� ������
    {
        var infoObject = Instantiate(infoWindow, transform);
        var script = infoObject.GetComponent<InfoPopUpUI>();
        script.SetInfoText("����� ��������");

        yield return new WaitForSeconds(1f);
        
        Destroy(infoObject);
        gameObject.SetActive(false);
    }
}