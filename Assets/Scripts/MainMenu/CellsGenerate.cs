using UnityEngine;
using UnityEngine.UI;

public class CellsGenerate : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;

    [SerializeField] private Sprite towerImage;
    [SerializeField] private Sprite tankImage;
    [SerializeField] private Sprite diamondImage;
    [SerializeField] private Sprite factoryImage;

    private const int Column = 9;
    private const int Row = 6;

    private CellJsonParser _cellJsonParser;
    private CellType[,] _fieldType;
    private GameObject[,] _field;

    private void Start()
    {
        _cellJsonParser = Camera.main.GetComponent<CellJsonParser>();
        _fieldType = _cellJsonParser.FieldType;
        _field = new GameObject[Row, Column];
        GenerateField();
    }

    private void GenerateField()
    {
        for (int i = 0; i < Row; i++)
        {
            for (int j = 0; j < Column; j++)
            {
                switch (_fieldType[i, j])
                {
                    case CellType.None:
                        CreateCell(i, j, 0, null, false, CellType.None);
                        break;
                    case CellType.Active:
                        CreateCell(i, j, 0, null, true, CellType.Active);
                        break;
                    case CellType.Tank:
                        CreateCell(i, j, 255, tankImage, true, CellType.Tank);
                        break;
                    case CellType.Tower:
                        CreateCell(i, j, 255, towerImage, true, CellType.Tower);
                        break;
                    case CellType.Diamond:
                        CreateCell(i, j, 255, diamondImage, true, CellType.Diamond);
                        break;
                    case CellType.Factory:
                        CreateCell(i, j, 255, factoryImage, true, CellType.Factory);
                        break;
                }

                Instantiate(_field[i, j], transform);
            }
        }
    }

    private void CreateCell(int i, int j, int alpha, Sprite sprite, bool interactable, CellType type)
    {
        //todo:  ���������� �������� �������� �� �������
        var icon = cellPrefab.transform.GetChild(0).GetComponentInChildren<Image>();
        var button = cellPrefab.transform.GetComponent<Button>();

        _field[i, j] = cellPrefab;
        icon.color = new Color(icon.color.a, icon.color.g, icon.color.b, alpha);
        icon.sprite = sprite;
        button.interactable = interactable;
        button.enabled = !(interactable && type == CellType.Active);
    }
}