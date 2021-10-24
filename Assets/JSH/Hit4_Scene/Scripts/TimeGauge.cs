using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeGauge : MonoBehaviour
{
    private readonly int EMERGENCY_TIME = 5;
    
    [SerializeField] private GameObject fadePanel;
    [SerializeField] private GameObject timeOverPanel;
    
    [SerializeField] private Image timeGaugeImg;
    
    [SerializeField] private Text curTimeText;

    [SerializeField] private Color normalColor;
    [SerializeField] private Color emergencyColor;

    private float curTime;
    private float maxTime;

    private float startTime;

    private bool isTimeOver = false;

    private HitScore timeGauge;

    private void Start()
    {
        // 테스트 코드
        SetTime(15.0f);

        timeGauge = FindObjectOfType<HitScore>();
    }

    private void Update()
    {
        CalcTime();
        GaugeUpdate();
    }

    /// <summary>
    /// 시간을 계산합니다.
    /// </summary>
    private void CalcTime()
    {
        if (Time.realtimeSinceStartup - startTime >= 0.1f)
        {
            if (curTime - 1.0f < 0)
            {
                isTimeOver = true;
                fadePanel.SetActive(true);
                timeOverPanel.SetActive(true);
                timeGaugeImg.fillAmount = 0.00000f;
                Invoke("SceneEnd", 2.0f);
            }
            else
            {
                if (curTime <= EMERGENCY_TIME)
                {
                    timeGaugeImg.color = emergencyColor;
                }
                else
                {
                    timeGaugeImg.color = normalColor;
                }
                
                curTime -= 0.1f;
                curTimeText.text = ((int)curTime).ToString();
            }

            startTime = Time.realtimeSinceStartup;
        }
    }
    
    /// <summary>
    /// 시간을 지정합니다.
    /// </summary>
    /// <param name="time"></param>
    public void SetTime(float time)
    {
        maxTime = curTime = time;
    }

    /// <summary>
    /// 시간을 초과한지 체크합니다.
    /// </summary>
    /// <returns></returns>
    public bool GetTimeOver()
    {
        return isTimeOver;
    }
    
    /// <summary>
    /// 게이지 이미지를 업데이트 합니다.
    /// </summary>
    private void GaugeUpdate()
    {
        timeGaugeImg.fillAmount = (float)curTime / (float)maxTime;
    }

    /// <summary>
    /// 씬을 이동합니다.
    /// </summary>
    private void SceneEnd()
    {
        GameSceneManager.GSM.SetTotalScore( GameSceneManager.GSM.GetTotalScore() + timeGauge.GetScore());
        GameSceneManager.GSM.SetHowManyWeLooped(GameSceneManager.GSM.GetHowManyWeLooped() + 1);
        GameSceneManager.GSM.LoadSceneAsync("Scene2");
        GameSceneManager.GSM.UnLoadSceneAsync("4_Hit");
    }
}
