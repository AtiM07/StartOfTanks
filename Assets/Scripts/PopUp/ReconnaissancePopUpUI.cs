using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReconnaissancePopUpUI : MonoBehaviour
{
    [SerializeField] private Button reconnaissanceButton;

    [SerializeField] private GameObject okPopUpWindow;
    private void Start()
    {
        reconnaissanceButton.onClick.AddListener(GoExplore);
    }
    
    private void GoExplore()
    {
        Instantiate(okPopUpWindow, transform.parent);
        Destroy(gameObject);
    }
}
