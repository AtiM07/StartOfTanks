using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] public Button addButton;
    [SerializeField] public Button minusButton;

    [SerializeField] private UnityEvent<object> onChange;

    public int Amount { get; set; } = 1;

    private int _count = 0;

    public int Count
    {
        get => _count;
        set
        {
            _count = value;
            countText.text = _count.ToString();
        }
    }

    private void Start()
    {
        addButton.onClick.AddListener(() => ChangeCount(Amount));
        minusButton.onClick.AddListener(() => ChangeCount(-Amount));
    }

    private void ChangeCount(int value)
    {
        if (_count + value <= 0)
            return;

        _count += value;
        countText.text = _count.ToString();
        onChange.Invoke(this);
    }
}