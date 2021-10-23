using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerFeature : MonoBehaviour
{
    [SerializeField] float _startTime;
    [SerializeField] TextMeshPro clockText;

    [SerializeField] bool _sceneAlreadyLoad;

    [SerializeField] float _innerTime;

    void Start()
    {
        Initialization();
    }

    void Initialization()
    {
        _innerTime = _startTime;
    }

    // Update is called once per frame
    void Update()
    {
        _innerTime -= Time.deltaTime;
        UpdateClockTime();
        if (_innerTime < 0f && _sceneAlreadyLoad == false)
        {
            GameSceneManager.GSM.SetGameOverType(GameOverType.¾À3½Ã°£ÃÊ°ú);
            GameSceneManager.GSM.LoadSceneAsync("5_GameOver");
            _sceneAlreadyLoad = true;
            GameSceneManager.GSM.UnLoadSceneAsync("SceneThree");
            GameSceneManager.GSM.UnLoadSceneAsync("SceneThreeShowThieve");
        }
    }

    void UpdateClockTime()
    {
        clockText.text = _innerTime.ToString("F2");
    }
}
