using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class SpawnBase : MonoBehaviour
{
    //protected...���̃N���X�Ɣh���N���X�ł̂ݎQ�Ɖ\
    //Min(n)...�C���X�y�N�^����l�𑀍삵���Ƃ��An�ȉ��ɂȂ�Ȃ�
    //Range(n,m)...�C���X�y�N�^����l�𑀍삵���Ƃ��A�l��n�ȏ�m�ȉ��Ɏ��߂�
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
