using UnityEngine;
using UnityEngine.UI;

public class OkPopUpUI : MonoBehaviour
{
    [SerializeField] private Button okButton;

    private void Start()
    {
        okButton.onClick.AddListener(() => Destroy(gameObject));
    }
}