using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPopUpUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI infoText;

    public void SetInfoText(string info)
    {
        infoText.text = info;
    }
}
