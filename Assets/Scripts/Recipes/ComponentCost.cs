using TMPro;
using UnityEngine;

public class ComponentCost : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI currentCost;
    [SerializeField] private TextMeshProUGUI allCost;

    public void UpdateView(Ingredient ingredient, Resources playerResources)
    {
        titleText.text = ingredient.Name;
        currentCost.text = ingredient.Count.ToString();

        allCost.text = playerResources.GetValueByTranslate(ingredient.Name).ToString();
    }
}