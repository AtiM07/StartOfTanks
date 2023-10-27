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

    [SerializeField] private Button produceButton;
    [SerializeField] private Button buildButton;
    [SerializeField] private ResourcesBar resourcesBar;

    private BuildJsonParser _buildJsonParser;
    private GameObject _activeBuild;
    private Resources _activeResources;
    private Player _player;
    
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

        produceButton.onClick.AddListener(Produce);
        buildButton.onClick.AddListener(Build);
    }

    private void Check(Building building, Sprite sprite) //������������ �� ��������� ������
    {
        nameText.text = building.characteristics.Name;
        descriptionText.text = building.characteristics.Description;
        buildImage.sprite = sprite;
        _activeResources = building.characteristics.Resources;
        resourcesBar.UpdateView(_activeResources); //����������� ����������� ��������
        buildButton.interactable =
            !building.isBuild && _player.resources < building.characteristics.Resources; //�������� �� ���������
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