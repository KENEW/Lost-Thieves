using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stuff
{
    [SerializeField] StuffBase _Base;
    float speed;
    float scale;
    float time;
    public StuffBase Base { get => _Base; }
    public float Speed { get => speed; }
    public float Scale { get => scale; }
    public float Time { get => time; }

    public void Init(int level)
    {
        speed = Random.Range(5, 5 + level);
        scale = Random.Range(0.5f, 1.5f);
        time = Random.Range(5f, 10f);
    }
}
