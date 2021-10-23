using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionSystem : MonoBehaviour
{
    [SerializeField] Scrollbar scrollbar;
    public Action OnSelectOver;
    public int curSelection = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            curSelection++;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            curSelection--;
        else if (Input.GetKeyDown(KeyCode.Space))
            OnSelectOver();
        curSelection = Mathf.Clamp(curSelection, 0, 4);
        ChangeValue(curSelection);
    }
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.RightArrow))
    //        curSelection++;
    //    else if (Input.GetKeyDown(KeyCode.LeftArrow))
    //        curSelection--;
    //    else if (Input.GetKeyDown(KeyCode.Space))
    //        OnSelectOver();
    //    curSelection = Mathf.Clamp(curSelection, 0, 4);
    //    ChangeValue(curSelection);
    //}
    void ChangeValue(int selection)
    {
        if (selection == 0)
            scrollbar.value = 0f - 0.07f;
        else if (selection == 1)
            scrollbar.value = 0.33f - 0.03f;
        else if (selection == 2)
            scrollbar.value = 0.66f + 0.03f;
        else if (selection == 3)
            scrollbar.value = 1 + 0.07f;
        //scrollbar.value = ((float)curSelection / 4) + 0.2f;
    }

}
