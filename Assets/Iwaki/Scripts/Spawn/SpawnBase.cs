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
    public bool Spawning { get; set; }

    [Header("Takinoko Settings")]
    [SerializeField] bool attachTakinokoSettings;
    [SerializeField] protected float speed, gameOverTimer;
    [SerializeField] protected TurnInterval turnInterval;
    [SerializeField] protected IdleDuration idleDuration;

    [Header("Debug")]
    [SerializeField] protected float t;
    [SerializeField] protected float interval;

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
        if (Spawning)
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

    public void CheckAndAttachTakinokoSettings(GameObject objectInstance)
    {
        if (attachTakinokoSettings)
        {
            var animator = objectInstance.GetComponent<TakinokoAnimation>();
            animator.speed = speed;
            animator.turnInterval = turnInterval;
            animator.idleDuration = idleDuration;

            objectInstance.GetComponent<GameOverTimer>().overTime = gameOverTimer;
        }
    }

    public abstract void Spawn();
}
