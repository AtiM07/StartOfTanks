using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using Newtonsoft.Json.Linq;

/// <summary>
/// ѕарсер глобальной карты
/// </summary>
public class CellJsonParser : MonoBehaviour, IJsonParser<CellType[,]>
{
    [SerializeField] private TextAsset jsonFile;

    /// <summary>
    /// √лобальна€ карта
    /// </summary>
    public CellType[,] FieldType { get; private set; }

    private int _column;
    private int _row;

    private void Start()
    {
        FieldType = Parsing();
    }

    public CellType[,] Parsing() //чтение расположени€ €чеек
    {
        var json = jsonFile.ToString();
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