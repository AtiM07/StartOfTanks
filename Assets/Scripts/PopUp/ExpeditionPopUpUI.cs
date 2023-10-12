using UnityEngine;
using UnityEngine.UI;

public class ExpeditionPopUpUI : MonoBehaviour
{
    [SerializeField] private Button resoursesButton;

    [SerializeField] private GameObject okPopUpWindow;
    private void Start()
    {
        resoursesButton.onClick.AddListener(GoExplore);
    }
    
    private void GoExplore()
    {
        var script = okPopUpWindow.GetComponent<OkPopUpUI>();
        script.SetResultText("Результат экспедиции");
        Instantiate(okPopUpWindow, transform.parent);
        Destroy(gameObject);
    }
}
