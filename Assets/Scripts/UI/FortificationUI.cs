using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
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
    [SerializeField] private TextMeshProUGUI recipeText; //��� ������������� �������
    [SerializeField] private Transform recipeComponentsParent;
    [SerializeField] private GameObject recipeElements; //���� �������
    [SerializeField] private Counter counter; //������� ���������� ������� �������

    [SerializeField] private Button produceButton;
    [SerializeField] private Button buildButton;
    [SerializeField] private Button exploredButton;
    [SerializeField] private ResourcesBar resourcesBar;

    private BuildJsonParser _buildJsonParser;
    private GameObject _activeBuild;
    private Resources _activeResources;
    private Recipe _activeRecipe;
    private Player _player;

    private List<GameObject> recipes = new();
    private List<GameObject> recipeComponents = new();
    [SerializeField] private UnityEvent<object> onChange;

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
                _activeBuild = building;
                Check(data, sprite);
            });
        }

        _activeBuild = buildingGroup[0];
        Check(buildingGroup[0].GetComponent<Building>(),
            buildingGroup[0].GetComponent<Image>().sprite); //���������� ������ �����

        produceButton.onClick.AddListener(() =>
        {
            Produce();
            onChange.Invoke(this);
        });
        buildButton.onClick.AddListener(() =>
        {
            Build();
            onChange.Invoke(this);
        });
        exploredButton.onClick.AddListener(() =>
        {
            _activeRecipe.IsExplored = true;
            IsExplored(_activeRecipe);
            onChange.Invoke(this);
        });
    }

    public void UpdateComponents() //���������� ��������� ����������� �������
    {
        for (int i = 0; i < recipeComponents.Count; i++)
        {
            recipeComponents[i].gameObject.GetComponent<ComponentCost>()
                .UpdateView(_activeRecipe.Ingredients[i], counter.Count / counter.Amount, _player.resources);
        }

        produceButton.interactable = _player.resources > _activeRecipe.Ingredients;
        LayoutRebuilder.ForceRebuildLayoutImmediate(recipeComponentsParent.GetComponent<RectTransform>());
    }

    private void Check(Building building, Sprite sprite) //������������ �� ��������� ������
    {
        ClearList(recipes);
        ClearList(recipeComponents);

        nameText.text = building.characteristics.Name;
        descriptionText.text = building.characteristics.Description;
        buildImage.sprite = sprite;
        _activeResources = building.characteristics.Resources;
        resourcesBar.UpdateView(_activeResources); //����������� ����������� ��������
        buildButton.interactable =
            !building.isBuild && _player.resources < building.characteristics.Resources; //�������� �� ���������

        RecipeButtonView(building.characteristics.Recipes);
    }

    private void ClearList(List<GameObject> obj) //������� ������ �������� ���������
    {
        obj.ForEach(Destroy);
        obj.Clear();
    }

    private void ActiveRecipeView(Recipe recipe) //��������� ������
    {
        _activeRecipe = recipe;
        recipeText.text = recipe.Name;
        counter.Amount = recipe.Count;
        counter.Count = recipe.Count;
        RecipeComponentsView(recipe.Ingredients);
        IsExplored(recipe);
        onChange.Invoke(this);
    }

    private void RecipeComponentsView(Ingredient[] recipeIngredients) //����������� ������������ �������
    {
        ClearList(recipeComponents);
        ClearList(recipeComponents);

        for (int i = 0; i < recipeIngredients.Length; i++)
        {
            var obj = Instantiate(recipeComponentPrefab, recipeComponentsParent.transform);
            recipeComponents.Add(obj);
        }

        produceButton.interactable = _player.resources > recipeIngredients;
    }

    private void RecipeButtonView(Recipe[] list) //������ �������� ������
    {
        foreach (var element in list)
        {
            var obj = Instantiate(recipeButtonPrefab, recipeButtonsParent.transform);
            var button = obj.GetComponent<Button>();
            button.onClick.AddListener(() => { ActiveRecipeView(element); });
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
        exploredButton.interactable = true;
    }

    private void Produce()
    {
        if (_activeRecipe is null)
            return;

        var amount = counter.Count / counter.Amount;
        foreach (var ingredient in _activeRecipe.Ingredients)
        {
            _player.resources.SetValue(ingredient.Name, -ingredient.Count * amount);
        }

        _player.resources.SetValue(_activeRecipe.Name, _activeRecipe.Count * amount);

        produceButton.interactable = _player.resources > _activeRecipe.Ingredients;
    }

    private void IsExplored(Recipe recipe)
    {
        recipeElements.SetActive(recipe.IsExplored);
        exploredButton.gameObject.SetActive(!recipe.IsExplored);

        exploredButton.interactable = _activeBuild.GetComponent<Building>().isBuild;
    }
}