using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void GameStart()
    {
        GameSceneManager.GSM.LoadSceneAsync("scene2");
        GameSceneManager.GSM.UnLoadSceneAsync("0_Title");
    }
}
