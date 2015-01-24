using UnityEngine;
using System.Collections;

public class RoundTimer : MonoBehaviour {

    public float time;
    public bool start, stop;

    void Start()
    {
        StartCountDown(time);
    }

    void Update()
    {

        if (start && !stop)
        {
            time -= 1 / Mathf.Pow(Time.deltaTime, -1);
        }
        else
        {
            start = false;
        }
    }

    public void StopCountDown()
    {
        stop = true;
    }

    public void StartCountDown(float _time)
    {
        time = _time;
        stop = false;
        start = true;
    }

    public float CountDownGet
    {
        get { return time; }
    }
}
