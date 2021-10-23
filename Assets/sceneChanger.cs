using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneChanger : MonoBehaviour
{
    private void Start()
    {
        GameSceneManager.GSM.LoadSceneAsync("SceneThree");
        GameSceneManager.GSM.UnLoadSceneAsync("Scene2");
    }
}
