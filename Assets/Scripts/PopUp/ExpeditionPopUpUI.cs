using System.Collections;
using System.Collections.Generic;
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
        Instantiate(okPopUpWindow, transform.parent);
        Destroy(gameObject);
    }
}
