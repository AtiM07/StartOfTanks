using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class CellJsonParser : MonoBehaviour
{
    [SerializeField] private TextAsset jsonFile;

    public CellType[,] FieldType { get; private set; }

    private int _column;
    private int _row;

    void Start()
    {
        FieldType = GetCells(jsonFile.ToString());
    }

    private CellType[,] GetCells(string json)
    {
        var jObject = JObject.Parse(json);
        
        int.TryParse(jObject["column"].ToString(), out _column);
        int.TryParse(jObject["row"].ToString(), out _row);
        var list = new CellType[_row, _column];
        
        var cells = JsonConvert.DeserializeObject<List<Cell>>(jObject["cells"].ToString());
        
        foreach (var cell in cells)
        {
            list[cell.Y, cell.X] = cell.Type;
        }
        
        return list;
    }
}