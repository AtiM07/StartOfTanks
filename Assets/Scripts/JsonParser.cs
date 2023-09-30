using System;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class JsonParser : MonoBehaviour
{
    [SerializeField] private TextAsset jsonFile;

    public CellType[,] FieldType { get; private set; }


    private int column;
    private int row;

    void Start()
    {
        FieldType = GetCells(jsonFile.ToString());
    }

    private CellType[,] GetCells(string json)
    {
        var jObject = JObject.Parse(json);
        
        int.TryParse(jObject["column"].ToString(), out column);
        int.TryParse(jObject["row"].ToString(), out row);
        var list = new CellType[column, row];

        return list;
    }
}