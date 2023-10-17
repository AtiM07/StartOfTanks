using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Пользовательский интерфейс ангара
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
            if (true) //проверка на корректность отряда
            {
                StartCoroutine(CloseHangar());
            }
        });
    }

    public void AddInSlot()
    {
        Debug.Log("Добавление на слот");
    }
    
    public void DeleteInSlot()
    {
        Debug.Log("Удаление из слота");
        
    }

    private IEnumerator CloseHangar() //выйти из ангара
    {
        var infoObject = Instantiate(infoWindow, transform);
        var script = infoObject.GetComponent<InfoPopUpUI>();
        script.SetInfoText("Отряд сохранен");

        yield return new WaitForSeconds(1f);
        
        Destroy(infoObject);
        gameObject.SetActive(false);
    }
}