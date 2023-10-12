using UnityEngine;
using UnityEngine.UI;

public class FortificationUI : MonoBehaviour
{
    [SerializeField] private Button nitratesButton;
    [SerializeField] private Button waterButton;
    [SerializeField] private Button gunpowderButton;
    [SerializeField] private Button organicButton;
    [SerializeField] private Button limestoneButton;
    [SerializeField] private Button produceButton;
    [SerializeField] private Button buildButton;

    private Button[] _recipes;
 
    private void Start()
    {
        _recipes = new[] { nitratesButton, waterButton, gunpowderButton, organicButton, limestoneButton };
        nitratesButton.onClick.AddListener(() => ChangeRecipe(0));
        waterButton.onClick.AddListener(() => ChangeRecipe(1));
        gunpowderButton.onClick.AddListener(() => ChangeRecipe(2));
        organicButton.onClick.AddListener(() => ChangeRecipe(3));
        limestoneButton.onClick.AddListener(() => ChangeRecipe(4));
        
        produceButton.onClick.AddListener(Produce);
        buildButton.onClick.AddListener(Build);
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
