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

    [SerializeField] private GameObject recipeButtonsParent; //�������
    [SerializeField] private GameObject recipeButtonPrefab;
    [SerializeField] private TextMeshProUGUI recipeText; //��� ������������� ������

    [SerializeField] private Button produceButton;
    [SerializeField] private Button buildButton;
    [SerializeField] private ResourcesBar resourcesBar;

    private BuildJsonParser _buildJsonParser;
    private GameObject _activeBuild;
    private Resources _activeResources;
    private Recipe _activeRecipe;
    private Player _player;
    private List<GameObject> recipes = new();

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
        ClearRecipe();

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
        
        //���������������� ��� ����������� �������
    }

    private void RecipeButtonView(Recipe[] list)
    {
        foreach (var element in list)
        {
            var obj = Instantiate(recipeButtonPrefab, recipeButtonsParent.transform);
            var label = obj.GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>();
            label.text = element.Name;
            recipes.Add(obj);
        }
        
        ActiveRecipeView(list[0]);
    }

    private void ClearRecipe()
    {
        foreach (var item in recipes)
        {
            Destroy(item);
        }
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