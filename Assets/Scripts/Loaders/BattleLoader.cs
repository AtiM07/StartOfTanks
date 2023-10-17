using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Загрузка боя
/// </summary>
public class BattleLoader : MonoBehaviour
{
    [SerializeField] private Slider sliderLeft; 
    [SerializeField] private Slider sliderRight;
    [SerializeField] private GameObject bangImage;
    [SerializeField] private GameObject okPopUpWindow;

    [SerializeField] private float loadTime = 0.0015f;

    void Start()
    {
        sliderLeft.value = 0;
        sliderRight.value = 0;
        bangImage.SetActive(false);
        StartCoroutine(Loading());
    }
    
    private IEnumerator Loading() //процесс загрузки
    {
        var time = loadTime;
        var value = 0f;
        while (value < 1)
        {
            yield return new WaitForSecondsRealtime(time);
            value += time;
            sliderLeft.value = value;
            sliderRight.value = value;
        }

        bangImage.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Result(); //to do: начало боя
    }
    
    private void Result() //открыть окно с результатами боя
    {
        var okObject = Instantiate(okPopUpWindow, transform.parent);
        var script = okObject.GetComponent<OkPopUpUI>();
        script.SetTitleText("Результат боя:");
        script.SetResultText("Бой прошел");
        script.okButton.onClick.AddListener(() => SceneManager.LoadScene("MainScene"));
    }
}