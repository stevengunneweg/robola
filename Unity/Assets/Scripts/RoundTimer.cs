using UnityEngine;
using System.Collections;

public class RoundTimer : MonoBehaviour {

    public float time;
    public bool start, stop;

    void Start()
    {
        //StartCountDown(time);
    }

    void Update()
    {

        if (start && !stop && time > 0)
        {
            time -= 1 * Time.deltaTime;
        }
        else
        {
			if (time < 0) {
				time = 0;
			}
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
