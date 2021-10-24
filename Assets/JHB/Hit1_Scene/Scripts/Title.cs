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
        GameSceneManager.GSM.SetHowManyWeLooped(0);
        GameSceneManager.GSM.SetTotalScore(0f);
        GameSceneManager.GSM.LoadSceneAsync("Scene2");
        GameSceneManager.GSM.UnLoadSceneAsync("0_Title");
    }
    private void CreditOpen()
    {
        //title.SetActive(false);
        credit.SetActive(true);
    }
    private void CreditClose()
    {
        //title.SetActive(true);
        credit.SetActive(false);
    }
    private void GameExit()
    {
#if UNITY_EDITOR
        Debug.Log("Exit Cilcked");
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE_WIN
        Application.Quit();
#else
        Application.Quit();
#endif
    }
}