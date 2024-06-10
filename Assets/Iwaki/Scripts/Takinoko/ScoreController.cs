using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    Animator animator;
    ScoreManager scoreManager;
    GameManager gameManager;
    GameOverTimer gameOverTimer;

    [SerializeField] int score;
    [SerializeField] bool isMushroom, isBamboo;
    public bool checkArea { get; set; }

    private void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        animator = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameOverTimer = GetComponent<GameOverTimer>();
    }

    private void Update()
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("Walk") || info.IsName("Idle"))
        {
            CheckArea();
        }
    }

    public void CheckArea()
    {
        if (scoreManager.GetContainsArea(transform.position) == 0)
        {
            if (isMushroom)
            {
                scoreManager.AddMushrooms(score);
            }
            else if(isBamboo)
            {
                gameManager.GameOver("GameOver(Wrong Sorting)");
            }
            Destroy(gameOverTimer);
            Destroy(this);
        }
        else if (scoreManager.GetContainsArea(transform.position) == 1)
        {
            if (isBamboo)
            {
                scoreManager.AddBamboo(score);
            }
            else if(isMushroom)
            {
                
                gameManager.GameOver("GameOver(Wrong Sorting)");
            }
            Destroy(gameOverTimer);
            Destroy(this);
        }
    }
}
