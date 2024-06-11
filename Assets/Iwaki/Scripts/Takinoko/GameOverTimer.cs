using UnityEngine;

public class GameOverTimer : MonoBehaviour
{
    [SerializeField] float overTime, t;
    GameManager gameManager;


    private void Start()
    {
        if (GameManager.isPlaying)
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
    }
    private void Update()
    {
        if (GameManager.isPlaying)
        {
            t += Time.deltaTime;

            if (t > overTime)
            {
                gameManager.GameOver("GameOver(TimeOver)");
            }
        }
    }
}
