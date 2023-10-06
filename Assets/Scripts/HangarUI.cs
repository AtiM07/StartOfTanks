using UnityEngine;
using UnityEngine.UI;

public class HangarUI : MonoBehaviour
{
    [SerializeField] private GameObject characteristics;
    [SerializeField] private GameObject slot1;
    [SerializeField] private GameObject slot2;
    [SerializeField] private GameObject slot3;
    [SerializeField] private GameObject slot4;

    private GameObject[] _slots;

    private void Start()
    {
        _slots = new[] { slot1, slot2, slot3, slot4 };
        slot1.GetComponent<Button>().onClick.AddListener(() => Click(0));
        slot2.GetComponent<Button>().onClick.AddListener(() => Click(1));
        slot3.GetComponent<Button>().onClick.AddListener(() => Click(2));
        slot4.GetComponent<Button>().onClick.AddListener(() => Click(3));
    }

    private void Click(int num)
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            var activeItem = _slots[i].transform.GetChild(0).GetComponent<Image>();
            activeItem.enabled = i == num;
        }
    }

    public void AddInSlot()
    {
        Debug.Log("Добавление на слот");
    }
    
    public void DeleteInSlot()
    {
        Debug.Log("Удаление из слота");
        
    }
}