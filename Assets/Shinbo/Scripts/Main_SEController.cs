using UnityEngine;

public class Main_SEController : MonoBehaviour
{
    AudioSource _audioSource;

    [Header("�N���b�N��")]
    [SerializeField] AudioClip _click;
    
    [Header("�Q�[���X�^�[�g��")]
    [SerializeField] AudioClip _gameStart;


    [Header("�܂݉�")]
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
            Debug.Log("�u_click�v�ɃN���b�N����SE���A�T�C�����Ă�������");
            return;
        }
        _audioSource.PlayOneShot(_click);
    }

    public void GameStartSE()
    {
        if (_gameStart == null)
        {
            Debug.Log("�u_gameStart�v�ɃQ�[���X�^�[�g����SE���A�T�C�����Ă�������");
            return;
        }
        _audioSource.PlayOneShot(_gameStart);
    }

    public void HoldSE()
    {
        if (_hold == null)
        {
            Debug.Log("�u_hold�v�ɂ����̂������񂾎���SE���A�T�C�����Ă�������");
            return;
        }
        _audioSource.PlayOneShot(_hold);
    }
}
