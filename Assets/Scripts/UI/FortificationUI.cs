using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���������������� ��������� ������� �����
/// </summary>
public class FortificationUI : MonoBehaviour
{
    //�������
    [SerializeField] private Button nitratesButton;
    [SerializeField] private Button waterButton;
    [SerializeField] private Button gunpowderButton;
    [SerializeField] private Button organicButton;
    [SerializeField] private Button limestoneButton;

    // ������
    [SerializeField] private GameObject towerDamage;
    [SerializeField] private GameObject tower;
    [SerializeField] private GameObject airTower;
    [SerializeField] private GameObject building;
    [SerializeField] private GameObject reservoirCyllinder;
    [SerializeField] private GameObject reservoirSphere;

    //��������������
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image buildImage;

    [SerializeField] private Button produceButton;
    [SerializeField] private Button buildButton;

    private BuildJsonParser _buildJsonParser;
    private GameObject _activeBuild;

    [SerializeField] private Player player;

    private void Start()
    {
        _buildJsonParser = Camera.main.GetComponent<BuildJsonParser>();

        towerDamage.GetComponent<Button>().onClick.AddListener(() =>
        {
            Check("�������� ���", towerDamage.GetComponent<Image>().sprite);
            _activeBuild = towerDamage;
        });
        tower.GetComponent<Button>().onClick.AddListener(() =>
        {
            Check("�������������� ���", tower.GetComponent<Image>().sprite);
            _activeBuild = tower;
        });
        airTower.GetComponent<Button>().onClick.AddListener(() =>
        {
            Check("���������� ���", airTower.GetComponent<Image>().sprite);
            _activeBuild = airTower;
        });
        building.GetComponent<Button>().onClick.AddListener(() =>
        {
            Check("���������� ���", building.GetComponent<Image>().sprite);
            _activeBuild = building;
        });
        reservoirCyllinder.GetComponent<Button>().onClick.AddListener(() =>
        {
            Check("�����-������ ���", reservoirCyllinder.GetComponent<Image>().sprite);
            _activeBuild = reservoirCyllinder;
        });
        reservoirSphere.GetComponent<Button>().onClick.AddListener(() =>
        {
            Check("�������� ���", reservoirSphere.GetComponent<Image>().sprite);
            _activeBuild = reservoirSphere;
        });

        produceButton.onClick.AddListener(Produce);
        buildButton.onClick.AddListener(Build);
    }

    private void Check(string buildName, Sprite image)
    {
        var builder = _buildJsonParser.Builders.First(x => x.Name == buildName);
        nameText.text = builder.Name;
        descriptionText.text = builder.Description;
        buildImage.sprite = image;

        buildButton.interactable = CheckResources(builder.Resources);
    }

    private bool CheckResources(Resources buildResources)
    {
        foreach (var prop in buildResources.GetType().GetFields())
        {
            var current = (int)prop.GetValue(buildResources);
            if (current != 0)
            {
                var value = (int)prop.GetValue(player.Resources);
                if (value < current)
                    return false;
            }
        }

        return true;
    }

    private void ChangeRecipe(int num)
    {
        Debug.Log("����� �������");
    }

    private void Produce()
    {
        Debug.Log("������������ �������");
    }

    private void Build()
    {
        //������� �������
        if (_activeBuild is null)
            return;
        var image = _activeBuild.GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 255);
    }
}