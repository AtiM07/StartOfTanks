using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���������������� ��������� ������� �����
/// </summary>
public class FortificationUI : MonoBehaviour
{
    [SerializeField] private GameObject[] buildingGroup; //������ ������

    [SerializeField] private TextMeshProUGUI nameText; //��� ������������� ������
    [SerializeField] private TextMeshProUGUI descriptionText; //��� ������������� ������
    [SerializeField] private Image buildImage; //��� ������������� ������

    [SerializeField] private Transform recipeButtonsParent; //�������
    [SerializeField] private GameObject recipeButtonPrefab;
    [SerializeField] private GameObject recipeComponentPrefab;
    [SerializeField] private TextMeshProUGUI recipeCountText;
    [SerializeField] private TextMeshProUGUI recipeText; //��� ������������� �������
    [SerializeField] private Transform recipeComponentsParent;

    [SerializeField] private Button produceButton;
    [SerializeField] private Button buildButton;
    [SerializeField] private ResourcesBar resourcesBar;

    private BuildJsonParser _buildJsonParser;
    private GameObject _activeBuild;
    private Resources _activeResources;
    private Recipe _activeRecipe;
    private Player _player;
    private List<GameObject> recipes = new();
    private List<GameObject> recipeComponents = new();

    private void Start()
    {
        _player = Camera.main.GetComponent<Player>();
        _buildJsonParser = Camera.main.GetComponent<BuildJsonParser>();

        foreach (var building in buildingGroup)
        {
            var data = building.GetComponent<Building>();
            data.characteristics =
                _buildJsonParser.Builders.First(x => x.Name == data.buildingName); //��������� ������������� ������
            var sprite = building.GetComponent<Image>().sprite;
            building.GetComponent<Button>().onClick.AddListener(() =>
            {
                Check(data, sprite);
                _activeBuild = building;
            });
        }

        Check(buildingGroup[0].GetComponent<Building>(),
            buildingGroup[0].GetComponent<Image>().sprite); //���������� ������ �����

        produceButton.onClick.AddListener(Produce);
        buildButton.onClick.AddListener(Build);
    }

    private void Check(Building building, Sprite sprite) //������������ �� ��������� ������
    {
        recipes.ForEach(Destroy);
        recipeComponents.ForEach(Destroy);

        nameText.text = building.characteristics.Name;
        descriptionText.text = building.characteristics.Description;
        buildImage.sprite = sprite;
        _activeResources = building.characteristics.Resources;
        resourcesBar.UpdateView(_activeResources); //����������� ����������� ��������
        buildButton.interactable =
            !building.isBuild && _player.resources < building.characteristics.Resources; //�������� �� ���������

        RecipeButtonView(building.characteristics.Recipes);
    }

    private void ActiveRecipeView(Recipe recipe)
    {
        _activeRecipe = recipe;
        recipeText.text = recipe.Name;
        recipeCountText.text = recipe.Count.ToString();
        
        RecipeComponentsView(recipe.Ingredients);
    }

    private void RecipeComponentsView(Ingredient[] recipeIngredients)
    {
        recipeComponents.ForEach(Destroy);
        foreach (var ingredient in recipeIngredients)
        {
            var obj = Instantiate(recipeComponentPrefab, recipeComponentsParent.transform);
            obj.GetComponent<ComponentCost>().UpdateView(ingredient, _player.resources);
            recipeComponents.Add(obj);
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(recipeComponentsParent.GetComponent<RectTransform>());
    }

    private void RecipeButtonView(Recipe[] list)
    {
        foreach (var element in list)
        {
            var obj = Instantiate(recipeButtonPrefab, recipeButtonsParent.transform);
            var button = obj.GetComponent<Button>();
            button.onClick.AddListener(() => ActiveRecipeView(element));
            var label = button.GetComponentInChildren<TextMeshProUGUI>();
            label.text = element.Name;
            recipes.Add(obj);
        }
        
        ActiveRecipeView(list[0]);
    }

    private void Build()
    {
        if (_activeBuild is null)
            return;

        _player.resources -= _activeResources;
        _activeBuild.GetComponent<Building>().isBuild = true;
        buildButton.interactable = false;
        var image = _activeBuild.GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 255);
    }

    private void Produce()
    {
        Debug.Log("������������ �������");
    }
}