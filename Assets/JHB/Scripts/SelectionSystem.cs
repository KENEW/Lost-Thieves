using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionSystem : MonoBehaviour
{
    [SerializeField] Scrollbar scrollbar;
    public Action OnSelectOver;
    int curSelection = 0;
    private void Start()
    {
        scrollbar.value = -0.08f + (0.39f * (float)curSelection);
    }
    // Update is called once per frame
    public void HandleUpdate()
    {
        int prevSelection = curSelection;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            curSelection++;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            curSelection--;
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            SetSelection();
            OnSelectOver();
        }
            
        curSelection = Mathf.Clamp(curSelection, 0, 4);

        if (prevSelection != curSelection)
            UpdateScrollSmooth(-0.08f + (0.39f * (float)curSelection));
    }
    public void UpdateScrollSmooth(float value)
    {
        if (value < scrollbar.value)
            StartCoroutine(UpdateDownScrollSmooth(value));
        else
            StartCoroutine(UpdateUpScrollSmooth(value));

    }
    public IEnumerator UpdateDownScrollSmooth(float value)
    {
        float curVal = scrollbar.value;
        float Diff = curVal - value;
        while (curVal - value > Mathf.Epsilon)
        {
            curVal -= Diff * Time.deltaTime * 2;
            scrollbar.value = curVal;
            yield return null;
        }
        scrollbar.value = value;

    }
    public IEnumerator UpdateUpScrollSmooth(float value)
    {
        float curVal = scrollbar.value;
        float Diff = curVal - value;
        while (value - curVal > Mathf.Epsilon)
        {
            curVal -= Diff * Time.deltaTime * 2;
            scrollbar.value = curVal;
            yield return null;
        }
        scrollbar.value = value;
    }
    void SetSelection()
    {
        // set selection into singleton class
    }
}
