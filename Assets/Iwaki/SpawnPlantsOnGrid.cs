using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;
using Random = UnityEngine.Random;

public class SpawnPlantsOnGrid : SpawnBase
{
    [SerializeField] Transform spawnPosObjectParent;

    Transform[] posObjects;
    Vector3[] spawnPos;

    public override void Spawn()
    {
        Debug.Log("spawn");


        posObjects = spawnPosObjectParent.GetChildren(); //ägí£ÉÅÉ\ÉbÉh

        CreateSpawnPos();

        foreach (var p in spawnPos)
        {
            var Objects = new GameObject[] { mushroom, bambooShoot };
            var spawnObj = GetRandomElementOfTwo(Objects, spawnWeight);
            var objectInstance = Instantiate(spawnObj, p, Quaternion.identity, transform);

            if (onDestroyOverMinInterval) Destroy(objectInstance, minInterval);
        }
    }

    void CreateSpawnPos()
    {
        var spawnCount = Mathf.Min(this.spawnCount, posObjects.Length);

        var spawnedIndexes = new List<int>();
        spawnPos = new Vector3[spawnCount];

            

        for(int i = 0; i < spawnCount; i++)
        {
            a:
            var posIndex = Random.Range(0, posObjects.Length);

            foreach (var spawnedIndex in spawnedIndexes)
            {
                if (posIndex == spawnedIndex)
                {
                    goto a;
                }
            }

            spawnedIndexes.Add(posIndex);

            spawnPos[i] = posObjects[posIndex].transform.position;
        }
    }


    T GetRandomElementOfTwo<T>(T[] array, float weight = 0.5f)
    {
        if (Random.Range(0f, 1f) < weight)
        {
            return array[0];
        }
        else
        {
            return array[1];
        }
    }

    T GetRandomElement<T>(T[] array)
    {
        return array[Random.Range(0, array.Length)];

    }

    
}

public static class Extends
{
    public static Transform[] GetChildren(this Transform parent)
    {
        var children = new Transform[parent.childCount];

        for(int i = 0;i < parent.childCount; i++)
        {
            children[i] = parent.GetChild(i);
        }

        return children;
    }
}
