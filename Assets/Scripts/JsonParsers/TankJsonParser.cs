using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class TankJsonParser : MonoBehaviour, IJsonParser<BaseTankCharacteristics[]>
{
    [SerializeField] private TextAsset jsonFile;

    public BaseTankCharacteristics[] Tanks { get; private set; }

    private void Start()
    {
        Tanks = Parsing();
    }

    public BaseTankCharacteristics[] Parsing()
    {
        var json = jsonFile.text;
        var jObject = JObject.Parse(json);

        return JsonConvert.DeserializeObject<BaseTankCharacteristics[]>(jObject["tanks"].ToString());
    }
}