using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScene : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameSceneManager.GSM.LoadSceneAsync("0_Title");
            GameSceneManager.GSM.LoadSceneAsync("5_GameScene");
        }
    }
}
