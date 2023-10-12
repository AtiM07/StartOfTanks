using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> selectors;
    private void Start()
    {
        foreach (var selector in selectors)
        {
            selector.GetComponent<Button>().onClick.AddListener(()=> Click(selector.name));
        }
    }

    private void Click(string objectName)
    {
        foreach (var selector in selectors)
        {
            var activeItem = selector.transform.GetChild(0).GetComponent<Image>();
            activeItem.enabled = selector.name == objectName;
        }
    }
}
