using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class SpawnBase : MonoBehaviour
{
    //protected...このクラスと派生クラスでのみ参照可能
    //Min(n)...インスペクタから値を操作したとき、n以下にならない
    //Range(n,m)...インスペクタから値を操作したとき、値をn以上m以下に収める
    [SerializeField] protected GameObject mushroom, bambooShoot;
    [SerializeField] protected bool onDestroyOverMinInterval, spawnOnStart;
    public bool Spawning { get; set; }

    [Space(16)]
    public bool attachTakinokoSettings;
    public TakinokoSetting takinokoSetting;

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
        interval = Random.Range(takinokoSetting.minInterval, takinokoSetting.maxInterval);
    }

    public void CheckAndAttachTakinokoSettings(GameObject objectInstance)
    {
        if (attachTakinokoSettings)
        {
            var animator = objectInstance.GetComponent<TakinokoAnimation>();
            animator.speed = takinokoSetting.speed;
            animator.turnInterval = takinokoSetting.turnInterval;
            animator.idleDuration = takinokoSetting.idleDuration;

            objectInstance.GetComponent<GameOverTimer>().overTime = takinokoSetting.gameOverTimer;
        }
    }

    public abstract void Spawn();
}
