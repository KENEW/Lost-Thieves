using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitScore : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    private int curScore = 0;

    //public PoolManager poolManager;

    
    public int GetScore()
    {
        return curScore;
    }

    public void AddScore(int score)
    {
        curScore += score;
        ScoreUpdate();
        //var text= PrepoolManager.ObjectDequeue("textPre");
        
    }

    public void SetScore(int score)
    {
        curScore = score;
        ScoreUpdate();
    }

    private void ScoreUpdate()
    {
        scoreText.text = curScore.ToString();
    }
}
