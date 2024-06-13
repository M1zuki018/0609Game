using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    string _gameScene = "Game";
    string _titleScene = "Title";
    string _resultScene = "Result";

    public void GameScene()
    {
        Invoke("Scene", 1);
    }

    void Scene() //タイトル→ゲーム画面、リトライ用
    {
        if(_gameScene == string.Empty)
        {
            Debug.Log("「_gameScene」に読み込むシーン名を入力してください");
            return;
        }
        SceneManager.LoadScene(_gameScene);
    }

    public void TitleScene()
    {
        Invoke("BackTitle", 1);
    }

    void BackTitle() //リザルト画面→タイトル画面用
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
