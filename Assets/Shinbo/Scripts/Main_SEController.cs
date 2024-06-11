using UnityEngine;

public class Main_SEController : MonoBehaviour
{
    AudioSource _audioSource;

    [Header("ゲームスタート時のSE")]
    [SerializeField] AudioClip _gameStart;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void GameStartSE()
    {
        if (_gameStart == null)
        {
            Debug.Log("「_gameStart」にゲーム開始ボタンを押したときのSEをアサインしてください");
            return;
        }
        _audioSource.PlayOneShot(_gameStart);
    }
}
