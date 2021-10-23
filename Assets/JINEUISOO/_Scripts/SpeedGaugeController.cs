using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedGaugeController : MonoBehaviour
{
    [SerializeField] float _addSpeedGaugePowerMulty;
    [SerializeField] float _minusGaugePowerMulty;
    [SerializeField] float _speedGagueValue;
    internal float SpeedGagueValue => _speedGagueValue;

    [SerializeField] Image _gaugeMovingImage;

    bool _keyDown, _keyUp;

    // �������� Speed Gague ���ҷ��� �޶����� ���ڴ�. ���� ���� ���� ����, �������� ������ ����.
    // �̴� �����ϰ�, �������� �����ų�, Ȥ�� ���� �����ϵ��� �صθ� ���ڴ�.

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _keyUp = true;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
            _keyDown = true;

        // Ű �ѹ��� �ѹ��� �����Ǿ�� �Ѵ�.
        if (_keyDown == true && _keyUp == true)
        {
            _speedGagueValue += 1 * _addSpeedGaugePowerMulty;
            _keyDown = false;
            _keyUp = false;
        }
        _speedGagueValue -= 1 * _minusGaugePowerMulty;

        UpdateSpeedGauge();
    }

    void UpdateSpeedGauge()
    {
        _speedGagueValue = Mathf.Clamp(_speedGagueValue, 0f, 1f);
        _gaugeMovingImage.fillAmount = _speedGagueValue;
    }
}