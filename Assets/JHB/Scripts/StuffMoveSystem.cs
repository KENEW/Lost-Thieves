using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StuffMoveSystem : MonoBehaviour
{
    [SerializeField] Transform rightUp;
    [SerializeField] Transform leftDown;
    [SerializeField] Transform rightUpLim;
    [SerializeField] Transform leftDownLim;
    [SerializeField] Text timeText;
    [SerializeField] Text startTimer;
    [SerializeField] List<Stuff> stuffs;
    [SerializeField] List<StuffMove> moves;
    [SerializeField] float LimTime;
    [SerializeField] int level;

    public Action OnMoveOver;
    float curTime;
    List<Stuff> stuffsList = new List<Stuff>();
    List<Stuff> answerList = new List<Stuff>();

    bool waitTime = true;
    float waitTimeInt = 6f;
    // Start is called before the first frame update
    public void HandleStart()
    {
        SetLevel();
        timeText.text = "10";
        startTimer.gameObject.SetActive(true);
        for (int i = 0; i < level; i++)
        {
            int index = UnityEngine.Random.Range(0, stuffs.Count);
            var tmp = stuffs[index];
            tmp.Init(level);
            stuffsList.Add(tmp);
        }
        while (stuffsList.Count != 0)
        {
            int index = UnityEngine.Random.Range(0, moves.Count);
            if (moves[index].MyStuff == null)
            {
                var x = UnityEngine.Random.Range(leftDown.position.x, rightUp.position.x);
                var y = UnityEngine.Random.Range(leftDown.position.y, rightUp.position.y);
                moves[index].Init(x, y, stuffsList[0]);
                Debug.Log(stuffsList[0].Base.Type);
                answerList.Add(stuffsList[0]);
                stuffsList.RemoveAt(0);
            }
        }
        curTime = LimTime;
    }
    public void MakeAnswer()
    {
        timeText.text = "10";
        startTimer.gameObject.SetActive(true);
        answerList = answerList.OrderBy(a => Guid.NewGuid()).ToList();

        var answer = answerList[0];
        answerList.RemoveAt(0);

        SetAnswer();

        while (answerList.Count != 0)
        {
            int index = UnityEngine.Random.Range(0, moves.Count);
            if (moves[index].MyStuff == null)
            {
                var x = UnityEngine.Random.Range(leftDown.position.x, rightUp.position.x);
                var y = UnityEngine.Random.Range(leftDown.position.y, rightUp.position.y);
                moves[index].Init(x, y, answerList[0]);
                Debug.Log(answerList[0].Base.Type);
                answerList.RemoveAt(0);
            }
        }
        curTime = LimTime;
    }
    // Update is called once per frame
    public void HandleUpdate()
    {
        if(waitTime)
        {
            waitTimeInt -= Time.deltaTime;
            if(waitTimeInt > 5)
            {
                startTimer.text = "나오는 사물을 기억하세요!";
            }
            else
            {
                startTimer.text = Mathf.Ceil(waitTimeInt).ToString("N0");
            }
            if (waitTimeInt <= 0)
            {
                waitTime = false;
                startTimer.gameObject.SetActive(false);
            }
                
        }
        else
        {
            curTime -= Time.deltaTime;
            timeText.text = curTime.ToString("N0");
            foreach (var move in moves)
            {
                if (move.MyStuff != null && curTime <= move.MyStuff.Time)
                {
                    move.Move();
                    LimitCheck(move);
                }
            }
            if (curTime <= 0f)
            {
                foreach (var move in moves)
                {
                    move.Init();
                }
                curTime = LimTime;
                waitTimeInt = 6f;
                waitTime = true;
                OnMoveOver();
            }
        }
    }
    void LimitCheck(StuffMove stuffMove)
    {
        if (stuffMove.transform.position.x <= leftDownLim.position.x || stuffMove.transform.position.x >= rightUpLim.position.x || stuffMove.transform.position.y <= leftDownLim.position.y || stuffMove.transform.position.y >= rightUpLim.position.y)
        {
            stuffMove.ChangeDir();
        }
    }
    void SetLevel()
    {
        // Load from singleton class
    }
    void SetAnswer()
    {
        // Set Answer into singleton class
    }
}
