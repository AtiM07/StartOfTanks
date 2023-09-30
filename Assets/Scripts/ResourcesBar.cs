using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ResourcesBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI oilCountText;
    [SerializeField] private TextMeshProUGUI coalCountText;
    [SerializeField] private TextMeshProUGUI oreCountText;
    [SerializeField] private TextMeshProUGUI limestoneCountText;
    [SerializeField] private TextMeshProUGUI sulphurCountText;
    [SerializeField] private TextMeshProUGUI waterCountText;
    [SerializeField] private TextMeshProUGUI moneyCountText;

    public void UpdateView(Resources resourses)
    {
        oilCountText.text = resourses.Oil.ToString();
        coalCountText.text = resourses.Coal.ToString();
        oreCountText.text = resourses.Ore.ToString();
        limestoneCountText.text = resourses.Limestone.ToString();
        sulphurCountText.text = resourses.Sulphur.ToString();
        waterCountText.text = resourses.Water.ToString();
        moneyCountText.text = resourses.Money.ToString();
    }
}