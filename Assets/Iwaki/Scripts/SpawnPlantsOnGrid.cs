using System.Collections.Generic;
using UnityEngine;

public class SpawnPlantsOnGrid : SpawnBase
{
    [Header("Settings")]
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
            var spawnObj = Objects.GetRandomElementOfTwo(takinokoSetting.spawnWeight);
            var objectInstance = Instantiate(spawnObj, p, Quaternion.identity, transform);

            CheckAndAttachTakinokoSettings(objectInstance);

            if (onDestroyOverMinInterval) Destroy(objectInstance, takinokoSetting.minInterval);
        }
    }

    void CreateSpawnPos()
    {
        var spawnCount = Mathf.Min(takinokoSetting.spawnCount, posObjects.Length);

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
}