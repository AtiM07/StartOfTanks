using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Пользовательский интерфейс окна сбора ресурсов 
/// </summary>
public class ReconnaissancePopUpUI : MonoBehaviour
{
    [SerializeField] private Button reconnaissanceButton;

    [SerializeField] private GameObject okPopUpWindow;
    private void Start()
    {
        reconnaissanceButton.onClick.AddListener(GoExplore);
    }
    
    private void GoExplore() //отправить на разведку
    {
        var okObject = Instantiate(okPopUpWindow, transform.parent);
        var script = okObject.GetComponent<OkPopUpUI>();
        script.SetTitleText("Результат разведки");
        script.SetResultText("0");
        Destroy(gameObject);
    }
}
