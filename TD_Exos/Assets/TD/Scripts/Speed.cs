using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Speed : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _speedUiText;

    private int _time = 0;
    private int _timeSpeedIndex = 0;

    private void Start()
    {
        _time = 1;
        _timeSpeedIndex = 0;
        Time.timeScale = _time;

        _speedUiText.text = "Speed x" + _time.ToString();
    }

    public void SpeedUpdater()
    {
        if (_timeSpeedIndex == 0)
        {
            _timeSpeedIndex = 1;
            Time.timeScale = 2;
        }
        else if (_timeSpeedIndex == 1)
        {
            _timeSpeedIndex = 2;
            Time.timeScale = 4;
        }
        else if (_timeSpeedIndex == 2)
        {
            _timeSpeedIndex = 0;
            Time.timeScale = 1;
        }

        _speedUiText.text = "Speed x" + Time.timeScale.ToString();
    }
}
