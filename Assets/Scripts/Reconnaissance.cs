using UnityEngine;
using UnityEngine.UI;

public class Reconnaissance : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    public void Open()
    {
        Debug.Log("click " + name);
    }
}
