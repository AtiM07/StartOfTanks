using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class TankJsonParser : MonoBehaviour, IJsonParser<Tank[]>
{
    [SerializeField] private TextAsset jsonFile;

    public Tank[] Tanks { get; private set; }

    private void Start()
    {
        Tanks = Parsing();
    }

    public Tank[] Parsing()
    {
        var json = jsonFile.text;
        var jObject = JObject.Parse(json);

        return JsonConvert.DeserializeObject<Tank[]>(jObject["tanks"].ToString());
    }
}