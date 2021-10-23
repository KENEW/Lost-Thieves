using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGroundSpawner : MonoBehaviour
{
    
    [SerializeField] GameObject[] _difficulty01PlatformPrefab;
    [SerializeField] Vector3 _movePlatformPos;
    
    [SerializeField] string _platformName;

    [SerializeField] Vector2 _cameraSize;

    Vector2 _colliderSize;

    void Start()
    {
        InstantiatePlatform();
        Initialization();
    }

    void Initialization()
    {
        _colliderSize = this.transform.GetComponent<BoxCollider2D>().size;
    }

    void Update()
    {
        
    }
    // 만약 트리거에 엔터하면
    // 랜덤하게 하나의 프리팹을 결정한다.(난이도 수정 용이하도록)
    // 만들어지는 위치는 스케일.x / 2 + 만들 프리팹의 크기 / 2 이다.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == _platformName)
            InstantiatePlatform();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == _platformName)
            Destroy(collision.gameObject);
    }

    void InstantiatePlatform()
    {
        int tempIntPrefabNumber = GetRandomPrefabNumber(_difficulty01PlatformPrefab);
        Vector2 tempVector2PlatformColiderSize = _difficulty01PlatformPrefab[tempIntPrefabNumber].GetComponent<BoxCollider2D>().size;

        float tempFloatInstPosX = tempVector2PlatformColiderSize.x * 1.5f + _colliderSize.x * 0.5f;
        float tempFloatInstPosY = _cameraSize.y * 0.5f + _colliderSize.y * 0.5f * -1f;

        Vector3 tempVector2InstantiatePosition = new Vector2(tempFloatInstPosX, tempFloatInstPosY);
        GameObject tempGOPlatfrom = Instantiate(_difficulty01PlatformPrefab[tempIntPrefabNumber], tempVector2InstantiatePosition, Quaternion.identity, this.transform);
        tempGOPlatfrom.name = _platformName;
        tempGOPlatfrom.GetComponent<TransfromMoveTo>().SetMovePos(_movePlatformPos);
    }

    int GetRandomPrefabNumber(GameObject[] difficultySet)
    {
        return Random.Range(0, difficultySet.Length);
    }
}
