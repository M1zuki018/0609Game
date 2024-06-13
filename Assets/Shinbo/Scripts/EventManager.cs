using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    GameObject _rulePanel;
    //インプットを制御しているオブジェクト、componentを取得

    int _countDown = 3;
    [SerializeField] GameObject _countDownArea;
    Text _countDownText;

    [SerializeField] UnityEvent startEvent;

    // Start is called before the first frame update
    void Start()
    {
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
            _rulePanel.SetActive(false);
            StartCoroutine("StartingPerformance");
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
            Destroy(_countDownArea);
            //入力制限を解除
            //たきのこを沸かせ始める
            startEvent.Invoke();
            Destroy(this);
        }
    }
}
