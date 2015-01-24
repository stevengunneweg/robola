using UnityEngine;
using System.Collections;

public class RoundTimer : MonoBehaviour {

    public float _time;
    public bool _start, _stop;

    void Update()
    {

        if (_start && !_stop)
        {
            _time -= 1 / Mathf.Pow(Time.deltaTime, -1);
        }
        else
        {
            _start = false;
        }
    }

    public void StopCountDown()
    {
        _stop = true;
    }

    public void StartCountDown(float time)
    {
        _time = time;
        _stop = false;
        _start = true;
    }

    public float CountDownGet
    {
        get { return _time; }
    }
}
