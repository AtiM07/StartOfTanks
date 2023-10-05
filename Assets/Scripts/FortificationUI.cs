using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FortificationUI : MonoBehaviour
{
    [SerializeField] private Button NitratesButton;
    [SerializeField] private Button WaterButton;
    [SerializeField] private Button GunpowderButton;
    [SerializeField] private Button OrganicButton;
    [SerializeField] private Button LimestoneButton;
    [SerializeField] private Button ProduceButton;
    [SerializeField] private Button BuildButton;

    private Button[] _recipes;
 
    private void Start()
    {
        _recipes = new[] { NitratesButton, WaterButton, GunpowderButton, OrganicButton, LimestoneButton };
        NitratesButton.onClick.AddListener(() => ChangeRecipe(0));
        WaterButton.onClick.AddListener(() => ChangeRecipe(1));
        GunpowderButton.onClick.AddListener(() => ChangeRecipe(2));
        OrganicButton.onClick.AddListener(() => ChangeRecipe(3));
        LimestoneButton.onClick.AddListener(() => ChangeRecipe(4));
        
        ProduceButton.onClick.AddListener(Produce);
        BuildButton.onClick.AddListener(Build);
    }

    private void ChangeRecipe(int num)
    {
        Debug.Log("Смена рецепта");
    }

    private void Produce()
    {
        Debug.Log("Изготовление ресурса");
    }

    private void Build()
    {
        Debug.Log("Постройка здания");
    }
}
