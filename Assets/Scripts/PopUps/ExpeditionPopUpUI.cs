using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Пользовательский интерфейс окна экспедиции
/// </summary>
public class ExpeditionPopUpUI : MonoBehaviour
{
    [SerializeField] private Button resoursesButton;

    [SerializeField] private GameObject okPopUpWindow;
    private void Start()
    {
        resoursesButton.onClick.AddListener(GoExplore);
    }
    
    private void GoExplore() //отправить в экспедицию
    {
        var okObject = Instantiate(okPopUpWindow, transform.parent);
        var script = okObject.GetComponent<OkPopUpUI>();
        script.SetTitleText("Создание добычи ресурсов");
        script.SetResultText("0");
        Destroy(gameObject);
    }
}
