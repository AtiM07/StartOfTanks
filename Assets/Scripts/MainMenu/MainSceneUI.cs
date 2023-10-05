using UnityEngine;
using UnityEngine.UI;

public class MainSceneUI : MonoBehaviour
{
    [SerializeField] private Button ReconnaissanceButton;
    [SerializeField] private Button ResourcesButton;
    [SerializeField] private Button HangarButton;
    [SerializeField] private Button FortificationButton;
    [SerializeField] private Button ManufactureButton;

    private void Start()
    {
        HangarButton.onClick.AddListener(()=> OpenPanel("HangarPanel"));
        FortificationButton.onClick.AddListener(()=> OpenPanel("FortificationPanel"));
        ManufactureButton.onClick.AddListener(()=> OpenPanel("ManufacturePanel"));
    }

    private void OpenPanel(string namePanel)
    {
        var panel = SearcherScript.GetPanel(transform.parent, namePanel);
        panel.SetActive(!panel.activeSelf);
    }
}