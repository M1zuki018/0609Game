using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class SpawnBase : MonoBehaviour
{
    //protected...このクラスと派生クラスでのみ参照可能
    //Min(n)...インスペクタから値を操作したとき、n以下にならない
    //Range(n,m)...インスペクタから値を操作したとき、値をn以上m以下に収める
    [SerializeField] protected GameObject mushroom, bambooShoot;
    [SerializeField, Min(0)] protected float minInterval, maxInterval;
    [SerializeField, Min(0)] protected int spawnCount;
    [SerializeField, Range(0, 1)] protected float spawnWeight;
    [SerializeField] protected bool onDestroyOverMinInterval, spawnOnStart;

    [SerializeField] protected float t, interval;
    public bool spawning { get; set; }

    private void Start()
    {
        if (spawnOnStart)
        {
            Spawn();
        }
        Init();
    }

    private void Update()
    {
        if (spawning)
        {
            t += Time.deltaTime;


            if (t > interval)
            {
                Spawn();
                Init();
            }
        }
    }

    public void Init()
    {
        t = 0;
        interval = Random.Range(minInterval, maxInterval);
    }

    public abstract void Spawn();
}
