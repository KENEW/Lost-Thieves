using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffMove : MonoBehaviour
{
    [SerializeField] Transform rightUp;
    [SerializeField] Transform leftDown;

    [SerializeField] Transform rightUpLim;
    [SerializeField] Transform leftDownLim;

    Stuff myStuff;
    Vector3 targetPos;
    Vector3 curPos;
    Vector3 DirVec;

    public Stuff MyStuff { get => myStuff; set => myStuff = value; }

    // Start is called before the first frame update
    void Start()
    {
        if (MyStuff != null)
        {
            GetComponent<SpriteRenderer>().sprite = myStuff.Base.Sprite;
            curPos = GetComponent<Transform>().position;
            GetComponent<Transform>().localScale *= MyStuff.Scale;
            targetPos.x = Random.Range(leftDown.position.x, rightUp.position.x);
            targetPos.y = Random.Range(leftDown.position.y, rightUp.position.y);
            DirVec = (targetPos - curPos).normalized;
        }
    }
    private void Update()
    {
        if (MyStuff != null)
        {
            transform.position += DirVec * myStuff.Speed * Time.deltaTime;
            LimitCheck();
        }
    }
    // Update is called once per frame
    void LimitCheck()
    {
        if (transform.position.x <= leftDownLim.position.x || transform.position.x >= rightUpLim.position.x || transform.position.y <= leftDownLim.position.y || transform.position.y >= rightUpLim.position.y)
        {
            DirVec *= -1;
        }
    }
}
