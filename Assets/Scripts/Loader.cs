using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    private Slider slider;

    [SerializeField] private float loadTime = 0.0015f;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 0;
        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        var time = loadTime;
        while (slider.value < 1)
        {
            yield return new WaitForSecondsRealtime(time);
            slider.value += time;
        }

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainScene");
    }
}