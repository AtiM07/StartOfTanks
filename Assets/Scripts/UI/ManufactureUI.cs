using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Пользовательский интерфейс производства
/// </summary>
public class ManufactureUI : MonoBehaviour
{
    [SerializeField] private GameObject[] tankGroup; //массив чертежей

    [SerializeField] private Button createButton;

    [SerializeField] private Transform mainParent;
    [SerializeField] private Transform improvmentsParent;
    [SerializeField] private Transform equipmentParent;

    [SerializeField] private GameObject activePanel;
    [SerializeField] private GameObject exploredPanel;

    [SerializeField] private Button exploredButton;

    [SerializeField] private ResourcesBar characteristic;

    private GameObject _activeTank;

    private void Start()
    {
        foreach (var item in tankGroup)
        {
            item.GetComponent<Button>().onClick.AddListener(() => { ActiveTank(item); });
        }

        ActiveTank(tankGroup[0]);
        createButton.onClick.AddListener(CreateTank);
    }

    private void ActiveTank(GameObject obj)
    {
        if (_activeTank is not null)
            _activeTank.GetComponent<Selector>().onActiveChange.Invoke(false);
        _activeTank = obj;
        _activeTank.GetComponent<Selector>().onActiveChange.Invoke(true);
        var tank = obj.GetComponent<Tank>();
        characteristic.UpdateView(tank);
    }

    private void CreateTank()
    {
        Debug.Log("Танк добавлен в ангар");
    }
}