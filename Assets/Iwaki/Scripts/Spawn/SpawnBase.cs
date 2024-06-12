using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class SpawnBase : MonoBehaviour
{
    //protected...���̃N���X�Ɣh���N���X�ł̂ݎQ�Ɖ\
    //Min(n)...�C���X�y�N�^����l�𑀍삵���Ƃ��An�ȉ��ɂȂ�Ȃ�
    //Range(n,m)...�C���X�y�N�^����l�𑀍삵���Ƃ��A�l��n�ȏ�m�ȉ��Ɏ��߂�
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
