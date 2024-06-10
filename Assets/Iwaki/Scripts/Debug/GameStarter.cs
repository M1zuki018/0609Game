using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public GameManager Manager;

    private void Start()
    {
        Manager.GameStart();
    }
}
