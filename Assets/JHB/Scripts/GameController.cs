using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { Day1, Night1, Day2, Select }
public class GameController : MonoBehaviour
{
    [SerializeField] StuffMoveSystem stuffMoveSystem;
    [SerializeField] MyAnimation myAnimation;
    [SerializeField] SelectionSystem selectSystem;

    State state = State.Day1;
    // Start is called before the first frame update
    void Start()
    {
        stuffMoveSystem.HandleStart();
        stuffMoveSystem.OnMoveOver += MoveOver;
        myAnimation.OnAnimOver += AnimOver;
        selectSystem.OnSelectOver += SelectOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Day1 || state == State.Day2)
            stuffMoveSystem.HandleUpdate();
        else if (state == State.Night1)
            myAnimation.HandleUpdate();
        else if (state == State.Select)
            selectSystem.HandleUpdate();

    }

    void MoveOver()
    {
        if(state == State.Day1)
        {
            stuffMoveSystem.gameObject.SetActive(false);
            myAnimation.gameObject.SetActive(true);
            state = State.Night1;
        }
        else if(state == State.Day2)
        {
            selectSystem.gameObject.SetActive(true);
            state = State.Select;
        }
    }
    void AnimOver()
    {
        if(state == State.Night1)
        {
            myAnimation.gameObject.SetActive(false);
            stuffMoveSystem.gameObject.SetActive(true);
            stuffMoveSystem.MakeAnswer();
            state = State.Day2;
        }
    }
    void SelectOver()
    {
        // TODO : goto battle scene
    }
}
