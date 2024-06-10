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

                objectInstance = Instantiate(spawnObj, RandomPosInCollider(spawnBoxCollider), Quaternion.identity, transform);

            }
            if (spawnCollider as CircleCollider2D)
            {
                var spawnCircleCollider = spawnCollider as CircleCollider2D;

                objectInstance = Instantiate(spawnObj, RandomPosInCollider(spawnCircleCollider), Quaternion.identity, transform);
            }

            if (onDestroyOverMinInterval) Destroy(objectInstance, minInterval);
        }
    }

    Vector3 RandomPosInCollider(BoxCollider2D collider)
    {
        var bounds = collider.bounds;

        Vector3 min = bounds.min;
        Vector3 max = bounds.max;

        var x = Random.Range(min.x, max.x);
        var y = Random.Range(min.y, max.y);

        var pos = new Vector3(x, y);
        return pos;
    }


    Vector3 RandomPosInCollider(CircleCollider2D collider)
    {
        Vector3 offset = (Vector3)collider.offset + transform.position;
        var radius = collider.radius;

        var pos = Quaternion.Euler(0, 0, Random.Range(0, 360)) * new Vector3(Random.Range(0, radius), 0) + offset;

        return pos;
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
