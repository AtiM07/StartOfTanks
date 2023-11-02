using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public string Name;
    [Description] public TankType Type;
    public int Armour;
    public string Speed;
    public Damage Damage;

    private bool Radio;

    public bool RadioValue
    {
        get => Radio;
        set
        {
            if (characteristic.Radio)
                Radio = value;
        }
    }

    [SerializeField] private int defaultMask;

    private int Mask = 0;

    public int MaskValue
    {
        get => Mask;
        set
        {
            if (characteristic.Mask)
                Mask = value;
        }
    }

    private bool Exploration;

    public bool ExplorationValue
    {
        get => Exploration;
        set
        {
            if (characteristic.Exploration)
                Exploration = value;
        }
    }

    private BaseTankCharacteristics characteristic;

    private TankJsonParser _tankJsonParser;

    private void Start()
    {
        _tankJsonParser = Camera.main.GetComponent<TankJsonParser>();

        CheckType();
    }

    private void CheckType()
    {
        var type = _tankJsonParser.Tanks.First(x => x.Type == Type);
        characteristic = type;
        MaskValue = defaultMask;
        RadioValue = type.Radio;
        ExplorationValue = type.Exploration;
    }

    public static string BoolToString(object value) => (bool)value ? "есть" : "нет";
}