using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScene : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameSceneManager.GSM.LoadSceneAsync("Scene2");
            GameSceneManager.GSM.LoadSceneAsync("5_GameScene");
        }
    }
}
