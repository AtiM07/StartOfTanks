using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Пользовательский интерфейс главной сцены
/// </summary>
public class MainSceneUI : MonoBehaviour
{
    [SerializeField] private Button reconnaissanceButton; //Сбор ресурсов 
    [SerializeField] private Button resourcesButton;
    [SerializeField] private Button hangarButton; //Ангар
    [SerializeField] private Button fortificationButton; //Укрепрайон
    [SerializeField] private Button manufactureButton; //Производство

    [SerializeField] private GameObject expeditionWindow; //окно экспедиции
    [SerializeField] private GameObject reconnaissanceWindow; //окно сбора ресурсов 

    private void Start()
    {
        hangarButton.onClick.AddListener(() => OpenPanel("HangarPanel")); 
        fortificationButton.onClick.AddListener(() => OpenPanel("FortificationPanel")); 
        manufactureButton.onClick.AddListener(() => OpenPanel("ManufacturePanel"));

        reconnaissanceButton.onClick.AddListener(() => OpenWindow(reconnaissanceWindow)); 
        resourcesButton.onClick.AddListener(() => OpenWindow(expeditionWindow)); 
    }

    private void OpenPanel(string namePanel)
    {
        var panel = SearcherScript.GetPanel(transform.parent, namePanel);
        panel.SetActive(!panel.activeSelf);
    }

    private void OpenWindow(GameObject prefab)
    {
        Instantiate(prefab, transform);
    }
}