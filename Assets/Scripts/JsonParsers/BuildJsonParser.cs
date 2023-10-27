using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

/// <summary>
/// ������ ������ ��� �����������
/// </summary>
public class BuildJsonParser : MonoBehaviour, IJsonParser<Builder[]>
{
    [SerializeField] private TextAsset jsonFile;
    
    public Builder[] Builders { get; private set; }

    private void Start()
    {
        Builders = Parsing();
    }
    
    public Builder[] Parsing() //������ ���������� � ��������� �������
    {
        var json = jsonFile.text;
        var jObject = JObject.Parse(json);
        
        return JsonConvert.DeserializeObject<Builder[]>(jObject["builds"].ToString());
    }
}
