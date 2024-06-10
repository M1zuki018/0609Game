using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.VFX;

public class SpawnPlantsRandom : SpawnBase
{
    [SerializeField] Collider2D spawnCollider;

    public override void Spawn()
    {
        Debug.Log("spawn");

        for (int i = 0; i < spawnCount; i++)
        {
            var Objects = new GameObject[] { mushroom, bambooShoot};
            var spawnObj = GetRandomElementOfTwo(Objects, spawnWeight);

            GameObject objectInstance = null;
            if (spawnCollider as BoxCollider2D)
            {
                var spawnBoxCollider = spawnCollider as BoxCollider2D;

                objectInstance = Instantiate(spawnObj, spawnBoxCollider.RandomPosInCollider(), Quaternion.identity, transform);

            }
            if (spawnCollider as CircleCollider2D)
            {
                var spawnCircleCollider = spawnCollider as CircleCollider2D;

                objectInstance = Instantiate(spawnObj, spawnCircleCollider.RandomPosInCollider(), Quaternion.identity, transform);
            }

            if (onDestroyOverMinInterval) Destroy(objectInstance, minInterval);
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
