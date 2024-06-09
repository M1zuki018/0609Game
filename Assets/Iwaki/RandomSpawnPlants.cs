using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.VFX;

public class RandomGrowPlants : MonoBehaviour
{
    [SerializeField] GameObject mushroom;
    [SerializeField] GameObject bambooShoot;
    [SerializeField] float minDelay;
    [SerializeField] float maxDelay;

    //[SerializeField] Vector2 spawnBoundsSize;
    [SerializeField] Collider2D spawnCollider;
    [SerializeField] int spawnCount;

    void Start()
    {
        Invoke(nameof(Spawn), Random.Range(minDelay, maxDelay));
    }

    void Spawn()
    {
        Debug.Log("spawn");

        for (int i = 0; i < spawnCount; i++)
        {
            var Objects = new GameObject[] { mushroom, bambooShoot};
            var spawnObj = GetRandomElement(Objects);


            if (spawnCollider as BoxCollider2D)
            {
                var spawnBoxCollider = spawnCollider as BoxCollider2D;

                Instantiate(spawnObj, RandomPosInCollider(spawnBoxCollider), Quaternion.identity, transform);

            }
            if (spawnCollider as CircleCollider2D)
            {
                var spawnCircleCollider = spawnCollider as CircleCollider2D;

                Instantiate(spawnObj, RandomPosInCollider(spawnCircleCollider), Quaternion.identity, transform);
            }
        }

        Invoke(nameof(Spawn), Random.Range(minDelay, maxDelay));
    }

    /*Vector3 RandomPosInBox(Vector2 size)
    {
        float px = size.x / 2;
        float py = size.y / 2;

        var x = Random.Range(-px, px);
        var y = Random.Range(-py, py);

        return new Vector3(x, y);
    }*/

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


    T GetRandomElement<T>(T[] array)
    {
        return array[Random.Range(0, array.Length)];
    }
}
