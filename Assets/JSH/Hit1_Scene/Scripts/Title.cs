using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public Button startBt;
    public Button creditBt;
    public Button ExitBt;

    private void Start()
    {
        startBt.onClick.AddListener(GameStart);
        creditBt.onClick.AddListener(CreditOpen);
        ExitBt.onClick.AddListener(GameExit);
    }

    private void GameStart()
    {
        GameSceneManager.GSM.LoadSceneAsync("Scene2");
        GameSceneManager.GSM.UnLoadSceneAsync("0_Tilte");
    }

    private void CreditOpen()
    {
        
    }

    private void CreditClose()
    {
        
    }

    private void GameExit()
    {
#if UNITY_EDITOR
              
      #endif
#if UNITY_STANDALONE_WIN
        
#endif
    }
}