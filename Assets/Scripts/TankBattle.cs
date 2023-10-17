using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// �������� (�������� ���)
/// </summary>
public class TankBattle : MonoBehaviour
{
    private Button _tankButton;

    private void Start()
    {
        _tankButton = GetComponent<Button>();
        _tankButton.onClick.AddListener( StartBattle);
    }

    private void StartBattle()
    {
        SceneManager.LoadScene("Battle");
    }
}
