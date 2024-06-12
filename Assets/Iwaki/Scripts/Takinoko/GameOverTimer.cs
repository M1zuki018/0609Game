using UnityEngine;

public class GameOverTimer : MonoBehaviour
{
    public float overTime;
    [SerializeField] float t;
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
