using UnityEngine;
using System.Collections;

public class BeginCountdown : MonoBehaviour{
    public float introTimer, RoundTime;
    public bool start, stop;

    private RoundTimer RT;
    private showBeginCountdown text;
    private Player[] players;

    void Awake()
    {
        text = GameObject.Find("BeginCountDownTimer").GetComponent<showBeginCountdown>();
        players = FindObjectsOfType<Player>();
        RT = GetComponent<RoundTimer>();
        RT.time = RoundTime;
        StartIntroCountDown(introTimer);

        foreach (Player p in players)
        {
            p.mayMove = false;
        }
    }

    void Update() {
        if (start && introTimer > 0)
        {
            introTimer -= 1 / Mathf.Pow(Time.deltaTime, -1);
        }
        else
        {
            if (introTimer < 0)
            {
                RT.StartCountDown(30);
                foreach (Player p in players)
                {
                    p.mayMove = true;
                }
                Destroy(text.gameObject);
                Destroy(this);
			}
        }
    }

    public void StartIntroCountDown(float _time)
    {
        introTimer = _time;
        start = true;
    }

    public int IntroCountDownGet
    {
        get { return (int)introTimer; }
    }
}
