using UnityEngine;
using UnityEngine.UI;

public class Manufacture : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
    }

    public void Open()
    {
        Debug.Log("click" + this.name);
    }
}