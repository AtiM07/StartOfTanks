using UnityEngine;

public class GlobalCard : MonoBehaviour
{
    public CellType[,] FieldType { get; private set; } =
    {
        {
            CellType.None, CellType.None, CellType.None, CellType.None, CellType.None, CellType.None, CellType.None, CellType.None, CellType.None
        },
        {
            CellType.Active, CellType.Active, CellType.None, CellType.None, CellType.None, CellType.None, CellType.None, CellType.None, CellType.None
        },
        {
            CellType.Active, CellType.Factory, CellType.Active, CellType.Active, CellType.Active, CellType.Active, CellType.None, CellType.None, CellType.None
        },
        {
            CellType.Active, CellType.Active, CellType.Active, CellType.Tank, CellType.Active, CellType.Active, CellType.Diamond, CellType.None, CellType.None
        },
        {
            CellType.Active, CellType.Active, CellType.Active, CellType.Active, CellType.Active, CellType.Active, CellType.None, CellType.None, CellType.None
        },
        {
            CellType.Tower, CellType.Active, CellType.Active, CellType.Active, CellType.Active, CellType.Active, CellType.Active, CellType.None, CellType.None
        }
    };
}