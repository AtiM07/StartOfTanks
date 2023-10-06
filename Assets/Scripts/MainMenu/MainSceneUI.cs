using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainSceneUI : MonoBehaviour
{
    [SerializeField] private Button reconnaissanceButton;
    [SerializeField] private Button resourcesButton;
    [SerializeField] private Button hangarButton;
    [SerializeField] private Button fortificationButton;
    [SerializeField] private Button manufactureButton;

    [SerializeField] private GameObject expeditionWindow;
    [SerializeField] private GameObject reconnaissanceWindow;

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