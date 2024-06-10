using UnityEngine;

public class Main_SEController : MonoBehaviour
{
    AudioSource _audioSource;

    [Header("�Q�[���X�^�[�g����SE")]
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
            Debug.Log("�u_gameStart�v�ɃQ�[���J�n�{�^�����������Ƃ���SE���A�T�C�����Ă�������");
            return;
        }
        _audioSource.PlayOneShot(_gameStart);
    }
}
