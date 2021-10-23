using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] GameObject _characterImageGO;
    [SerializeField] SpeedGaugeController _gaugeController;

    [SerializeField] float _movingSpeedMinimum = 0.3f;

    [SerializeField] float _movingSpeed;

    Rigidbody2D _characterRB;

    // Start is called before the first frame update
    void Start()
    {
        _characterRB = _characterImageGO.GetComponent<Rigidbody2D>();
        _characterImageGO.transform.position = new Vector2(0f, -4.15f);
    }

    // Update is called once per frame
    void Update()
    {
        float tempFloatXPos;
        float tempFloatYPos;

        tempFloatXPos = _characterImageGO.transform.position.x + (_movingSpeed * _gaugeController.SpeedGagueValue) - _movingSpeedMinimum;
        tempFloatYPos = _characterImageGO.transform.position.y;

        Vector2 tempVector2CharacterPos = new Vector2(tempFloatXPos, tempFloatYPos);

         _characterRB.MovePosition(tempVector2CharacterPos);
        
    }
}
