using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    //インプットを制御しているオブジェクト、componentを取得
    GameObject _startObj;
    GameObject _managerObj;

    //開始演出関連の宣言
    GameObject _rulePanel;
    bool _isFirst;
    int _countDown = 3;
    [SerializeField] GameObject _countDownArea;
    [SerializeField] GameObject _gameCanvas;
    Text _countDownText;
    Main_SEController _seSource;
    AudioSource _bgmas;

    private void Awake()
    {
        _startObj = GameObject.Find("Start");
        _startObj.SetActive(false);
        _managerObj = GameObject.Find("GameManager");
        _managerObj.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        _rulePanel = GameObject.Find("RuleExplanation");
        _countDownText = _countDownArea.GetComponent<Text>();
        _gameCanvas.SetActive(false);

        GameObject _bgmObj = GameObject.Find("BGM");
        _bgmas = _bgmObj.GetComponent<AudioSource>();
        GameObject _seObj = GameObject.Find("SE");
        _seSource = _seObj.GetComponent<Main_SEController>();
    }

    // Update is called once per frame
    void Update()
    {
        //クリックされたらパネルを非表示にする
        if (Input.GetButtonDown("Fire1"))
        {
            if (!_isFirst)
            {
                _seSource.ClickSE();
                _rulePanel.SetActive(false);
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
            yield return new WaitForSeconds(1);
            _countDown--;
            StartCoroutine("StartingPerformance");
        }
        else
        {
            _seSource.GameStartSE();
            _bgmas.Play();
            Destroy(_countDownArea);
            _startObj.SetActive(true);
            _managerObj.SetActive(true);
            _gameCanvas.SetActive(true);
        }
    }
}
