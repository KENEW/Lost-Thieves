using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffMove : MonoBehaviour
{
    private Stuff myStuff;
    private Vector3 originPos;
    private Vector3 targetPos;
    private Vector3 curPos;
    private Vector3 dirVec;
    public Stuff MyStuff { get => myStuff; }
    public Vector3 DirVec { get => dirVec; }
    private void Awake()
    {
        originPos = GetComponent<Transform>().position;
    }
    public void Init(float x, float y, Stuff stuff)
    {
        myStuff = stuff;
        curPos = GetComponent<Transform>().position;
        
        GetComponent<Transform>().localScale *= MyStuff.Scale;
        GetComponent<SpriteRenderer>().sprite = myStuff.Base.Sprite;
        targetPos = new Vector3(x, y, 0.5f);
        dirVec = (targetPos - curPos).normalized;

        
    }
    public void Move()
    {
        transform.position += dirVec * myStuff.Speed * Time.deltaTime;
    }
    public void ChangeDir()
    {
        dirVec *= -1;
    }
    public void Init()
    {
        transform.position = originPos;
        myStuff = null;
    }
}
