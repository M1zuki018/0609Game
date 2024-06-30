using UnityEditor;
using UnityEngine;

public class SpawnPlantsRandom : SpawnBase
{
    [Header("Settings")]
    [SerializeField] Collider2D spawnCollider;

    public override void Spawn()
    {
        Debug.Log("spawn");

        for (int i = 0; i < takinokoSetting.spawnCount; i++)
        {
            var Objects = new GameObject[] { mushroom, bambooShoot };
            var spawnObj = GetRandomElementOfTwo(Objects, takinokoSetting.spawnWeight);

            GameObject objectInstance = null;

            objectInstance = Instantiate(spawnObj, spawnCollider.RandomPosInCollider(), Quaternion.identity, transform);

            CheckAndAttachTakinokoSettings(objectInstance);

            if (onDestroyOverMinInterval) Destroy(objectInstance, takinokoSetting.minInterval);
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
