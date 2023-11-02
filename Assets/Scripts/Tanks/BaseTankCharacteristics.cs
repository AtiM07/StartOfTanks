using System;

[Serializable]
public class BaseTankCharacteristics
{
    public TankType Type;
    public bool Body;
    public GunType[] Power;
    public ArmourType Armour;
    public bool Radio;
    public bool Mask;
    public bool Exploration;
    public int MaxFuel;
    public int MaxShells;
    public int Cost;
}