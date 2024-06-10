using System.Collections.Generic;
using UnityEngine;

public class SpawnPlantsOnGrid : SpawnBase
{
    [SerializeField] Transform spawnPosObjectParent;

    Transform[] posObjects;
    Vector3[] spawnPos;

    public override void Spawn()
    {
        Debug.Log("spawn");


        posObjects = spawnPosObjectParent.GetChildren(); //�g�����\�b�h

        CreateSpawnPos();

        foreach (var p in spawnPos)
        {
            var Objects = new GameObject[] { mushroom, bambooShoot };
            var spawnObj = Objects.GetRandomElementOfTwo(spawnWeight);
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
}