using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    GameObject _rulePanel;
    //インプットを制御しているオブジェクト、componentを取得

    bool _isFirst;
    int _countDown = 3;
    [SerializeField] GameObject _countDownArea;
    Text _countDownText;

    [SerializeField] GameObject _seObj;
    Main_SEController _SEController;
    AudioSource _audioSource;

    [SerializeField] UnityEvent startEvent;

    // Start is called before the first frame update
    void Start()
    {
        _SEController = _seObj.GetComponent<Main_SEController>();
        GameObject _bgmObj = GameObject.Find("BGM");
        _audioSource = _bgmObj.GetComponent<AudioSource>();

        _rulePanel = GameObject.Find("RuleExplanation");
        //インプットを制御しているcomponent.enable = false;
        _countDownText = _countDownArea.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //クリックされたらパネルを非表示にする
        if (Input.GetButtonDown("Fire1"))
        {
            if (!_isFirst)
            {
                _rulePanel.SetActive(false);
                //_SEController.ClickSE();
                StartCoroutine("StartingPerformance");
                _isFirst = true;
            }
            
        }
    }

    //開始演出
    IEnumerator StartingPerformance()
    {
        _countDownText.text = _countDown.ToString();

        if (_countDown != 0)
        {
            _countDown--;
            _SEController.ClickSE();
            yield return new WaitForSeconds(1);
            StartCoroutine("StartingPerformance");
        }
        else
        {
            Destroy(_countDownArea);
            _SEController.GameStartSE();
            _audioSource.Play();
            //入力制限を解除
            //たきのこを沸かせ始める
            startEvent.Invoke();
            Destroy(this);
        }
    }
}
