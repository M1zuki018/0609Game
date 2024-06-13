using UnityEngine;

public class Main_SEController : MonoBehaviour
{
    AudioSource _audioSource;

    [Header("クリック音")]
    [SerializeField] AudioClip _click;
    
    [Header("ゲームスタート音")]
    [SerializeField] AudioClip _gameStart;


    [Header("つまみ音")]
    [SerializeField] AudioClip _hold;


    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void ClickSE()
    {
        if (_click == null)
        {
            Debug.Log("「_click」にクリック時のSEをアサインしてください");
            return;
        }
        _audioSource.PlayOneShot(_click);
    }

    public void GameStartSE()
    {
        if (_gameStart == null)
        {
            Debug.Log("「_gameStart」にゲームスタート時のSEをアサインしてください");
            return;
        }
        _audioSource.PlayOneShot(_gameStart);
    }

    public void HoldSE()
    {
        if (_hold == null)
        {
            Debug.Log("「_hold」にたきのこをつかんだ時のSEをアサインしてください");
            return;
        }
        _audioSource.PlayOneShot(_hold);
    }
}
