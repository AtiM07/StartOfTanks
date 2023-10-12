using UnityEngine;
using UnityEngine.UI;

public class CellsGenerate : MonoBehaviour
{
    [SerializeField] private GameObject disactivePrefab;
    [SerializeField] private GameObject activePrefab;
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private GameObject tankPrefab;
    [SerializeField] private GameObject diamondPrefab;
    [SerializeField] private GameObject factoryPrefab;

    private const int Column = 9;
    private const int Row = 6;

    private CellJsonParser _cellJsonParser;

    private void Start()
    {
        _cellJsonParser = Camera.main.GetComponent<CellJsonParser>();
        GenerateField();
    }

    private void GenerateField()
    {
        for (int i = 0; i < Row; i++)
        {
            for (int j = 0; j < Column; j++)
            {
                switch (_cellJsonParser.FieldType[i, j])
                {
                    case CellType.None:
                        Instantiate(disactivePrefab, transform);
                        break;
                    case CellType.Active:
                        Instantiate(activePrefab, transform);
                        break;
                    case CellType.Tank:
                        Instantiate(tankPrefab, transform);
                        break;
                    case CellType.Tower:
                        Instantiate(towerPrefab, transform);
                        break;
                    case CellType.Diamond:
                        Instantiate(diamondPrefab, transform);
                        break;
                    case CellType.Factory:
                        Instantiate(factoryPrefab, transform);
                        break;
                }
            }
        }
    }
}