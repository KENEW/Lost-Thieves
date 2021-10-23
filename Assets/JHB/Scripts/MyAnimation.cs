using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MyAnimation : MonoBehaviour
{
    [SerializeField] List<Sprite> sprites;
    [SerializeField] float passTime;
    [SerializeField] Image ui;
    float curTime = 0;
    int curIndex = 0;

    public Action OnAnimOver;
    private void Start()
    {
        ui.sprite = sprites[curIndex];
    }
    public void HandleUpdate()
    {
        curTime += Time.deltaTime;
        if(curTime >= passTime)
        {
            curIndex++;
            if (curIndex >= sprites.Count)
            {
                curIndex = 0;
                OnAnimOver();
            }
            ui.sprite = sprites[curIndex];
            curTime = 0;
        }
    }
}
