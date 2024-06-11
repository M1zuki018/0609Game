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
        if (GameManager.isPlaying)
        {
            scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
            animator = GetComponent<Animator>();
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameOverTimer = GetComponent<GameOverTimer>();
        }
    }

    private void Update()
    {
        if (GameManager.isPlaying)
        {
            AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
            if (info.IsName("Walk") || info.IsName("Idle") || info.IsName("Drop"))
            {
                AreaCheck();
            }
        }
    }

    private void AreaCheck()
    {
        if (ScoreManager.GetContainsArea(transform.position) == 0)
        {
            if (isMushroom)
            {
                ScoreManager.AddMushrooms(1);
                ScoreManager.AddScore(score);
            }
            else if (isBamboo)
            {
                gameManager.GameOver("GameOver(Wrong Sorting)");
            }
            GetComponent<TakinokoAnimation>().GoalLeft();
            Destroy(gameOverTimer);
            Destroy(this);
        }
        else if (ScoreManager.GetContainsArea(transform.position) == 1)
        {
            if (isBamboo)
            {
                ScoreManager.AddBamboo(1);
                ScoreManager.AddScore(score);
            }
            else if(isMushroom)
            {
                
                gameManager.GameOver("GameOver(Wrong Sorting)");
            }
            GetComponent<TakinokoAnimation>().GoalRight();
            Destroy(gameOverTimer);
            Destroy(this);
        }
    }
}
