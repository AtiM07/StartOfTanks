using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpUI : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    void Start()
    {
     closeButton.onClick.AddListener(()=> Destroy(gameObject));
    }
}
