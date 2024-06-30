using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent gameStartEvent, gameEndEvent;
    public float gameTime, endTime;
    public static bool isPlaying;

    public void GameStart()
    {
        isPlaying = true;
        gameStartEvent.Invoke();
        gameObject.SetActive(true);
        gameTime = 0;
    }

    public void GameOver(string message = null)
    {
        if (message != null) Debug.Log(message);
        GameEnd();
    }


    public void GameEnd(string message = null)
    {
        if (message != null) Debug.Log(message);
        isPlaying = false;
        gameEndEvent.Invoke();
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (gameTime > endTime)
        {
            GameEnd("GameEnd(Time Up)");
        }
        else
        {
            gameTime += Time.deltaTime;
        }
    }
}
