using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProcesser : MonoBehaviour
{
    [SerializeField] SpawnBase spawn;
    [SerializeField] TakinokoSetting[] settings;
    [SerializeField] float t;
    [SerializeField] int index;


    void Start()
    {
        StartCoroutine(Process(settings[index]));
    }

    IEnumerator Process(TakinokoSetting setting)
    {
        spawn.takinokoSetting = setting;
        index++;
        yield return new WaitForSeconds(setting.duration);
        if (index < settings.Length)
        {
            yield return Process(settings[index]);
        }
        else
        {
            Debug.Log("ゲームプロセス終了");
        }
    }
}

[Serializable]
public class TakinokoSetting
{
    public float duration, speed, gameOverTimer;
    public float minInterval, maxInterval;
    public int spawnCount;
    [Range(0, 1)]public float spawnWeight;
    public TurnInterval turnInterval;
    public IdleDuration idleDuration;
}
