using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    Text _text;
    int _score = 5; //あとでいわきさんに合わせて書き換え

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
        _text.text = ("Score：" +  _score.ToString());
    }
}
