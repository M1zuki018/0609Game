using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] string _gameScene;
    [SerializeField] string _titleScene;
    [SerializeField] string _resultScene;

    public void Scene() //タイトル→ゲーム画面、リトライ用
    {
        if(_gameScene == string.Empty)
        {
            Debug.Log("「_gameScene」に読み込むシーン名を入力してください");
            return;
        }
        SceneManager.LoadScene(_gameScene);
    }

    public void BackTitel() //リザルト画面→タイトル画面用
    {
        if (_titleScene == string.Empty)
        {
            Debug.Log("「_titleScene」に読み込むシーン名を入力してください");
            return;
        }
        SceneManager.LoadScene(_titleScene);
    }

    public void Result() //ゲーム画面→リザルト画面用
    {
        if (_resultScene == string.Empty)
        {
            Debug.Log("「_resultScene」に読み込むシーン名を入力してください");
            return;
        }
        SceneManager.LoadScene(_resultScene);
    }
}
