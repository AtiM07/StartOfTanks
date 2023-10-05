
using System;
using JetBrains.Annotations;
using UnityEngine;

public static class SearcherScript
{
    public static GameObject GetPanel(Transform canvas, string name)
    {
        for (int i = 0; i < canvas.childCount; i++)
        {
            if (canvas.GetChild(i).name == name)
            {
                return canvas.GetChild(i).gameObject;
            }
        }

        throw new ArgumentNullException("Панель не найдена");
    }
}
