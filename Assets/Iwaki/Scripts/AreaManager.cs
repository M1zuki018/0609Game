using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    [SerializeField] Collider2D mushroomArea, bambooArea;
    static Collider2D MushroomArea, BambooArea;

    private void Awake()
    {
        MushroomArea = mushroomArea;
        BambooArea = bambooArea;
    }

    public static bool GetContainsArea(Area area, Vector3 position)
    {
        if (!MushroomArea || !BambooArea)
        {
            Debug.LogWarning("Scene上にAreaManagerが無いか、Collider2Dがアサインされていません");
            return false;
        }
        switch (area)
        {
            case Area.Mushroom:
                if (MushroomArea.bounds.Contains(position))
                {
                    return true;
                }
                break;
            case Area.Bamboo:
                if (BambooArea.bounds.Contains(position))
                {
                    return true;
                }
                break;
            default:
                return false;
        }
        return false;
    }
}

public enum Area
{
    Mushroom,
    Bamboo,
}

