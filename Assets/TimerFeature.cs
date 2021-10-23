using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerFeature : MonoBehaviour
{
    [SerializeField] float _startTime;

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
    }

    void UpdateClockTime()
    {

    }
}
