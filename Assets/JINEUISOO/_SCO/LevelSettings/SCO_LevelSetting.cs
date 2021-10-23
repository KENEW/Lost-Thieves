using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettingA", menuName = "ScriptableObject/Creat New LevelSetting")]
[System.Serializable]
public class SCO_LevelSetting : ScriptableObject
{
    [SerializeField] float _startTime;
    [SerializeField] float _moveSpeed;














    public float StartTIme => _startTime;
    public float MoveSpeed => _moveSpeed;
}
