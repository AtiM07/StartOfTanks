using System;
using UnityEngine;

[Serializable]
public class Cell : MonoBehaviour
{
    public CellType Type = CellType.None;
    public int X;
    public int Y;
}