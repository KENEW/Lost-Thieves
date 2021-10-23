using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    [SerializeField] Button startBt;
    [SerializeField] Button creditBt;
    [SerializeField] Button ExitBt;
    [SerializeField] Button creditpanel;

    [SerializeField] GameObject title;
    [SerializeField] GameObject credit;
    private void Start()
    {
        startBt.onClick.AddListener(GameStart);
        creditBt.onClick.AddListener(CreditOpen);
        ExitBt.onClick.AddListener(GameExit);
        creditpanel.onClick.AddListener(CreditClose);
    }
    private void GameStart()
    {
        GameSceneManager.GSM.LoadSceneAsync("Scene2");
        GameSceneManager.GSM.UnLoadSceneAsync("0_Tilte");
    }
    private void CreditOpen()
    {
        title.SetActive(false);
        credit.SetActive(true);
    }
    private void CreditClose()
    {
        title.SetActive(true);
        credit.SetActive(false);
    }
    private void GameExit()
    {
        Application.Quit();
    #if UNITY_EDITOR
              
          #endif
    #if UNITY_STANDALONE_WIN
        
    #endif
    }
}