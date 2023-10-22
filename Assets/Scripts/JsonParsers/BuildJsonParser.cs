using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

/// <summary>
/// Парсер зданий для укрепрайона
/// </summary>
public class BuildJsonParser : MonoBehaviour, IJsonParser<Builders[]>
{
    [SerializeField] private TextAsset jsonFile;
    
    public Builders[] Builders { get; private set; }

    private void Start()
    {
        Builders = Parsing();
    }
    
    public Builders[] Parsing() //чтение информации о возможных зданиях
    {
        var json = jsonFile.ToString();
        var jObject = JObject.Parse(json);

        var jArray = JArray.Parse(jObject["builds"].ToString());
        
        return JsonConvert.DeserializeObject<Builders[]>(jObject["builds"].ToString());
    }
}
