using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverTimer : MonoBehaviour
{
    [SerializeField] float overTime, t;
    GameManager gameManager;


    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        t += Time.deltaTime;

        if (t > overTime && GameManager.isPlaying)
        {
            gameManager.GameOver("GameOver(TimeOver)");
        }
    }
}
