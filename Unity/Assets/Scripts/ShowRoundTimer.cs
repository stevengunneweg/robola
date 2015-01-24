using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowRoundTimer : MonoBehaviour {

    private RoundTimer _timer;
    private Text _text;

    void Awake()
    {
        _timer = GameObject.Find("GameManager").GetComponent<RoundTimer>();
        _text = GetComponent<Text>();
    }

    void Update()
    {
        _text.text = _timer.CountDownGet.ToString("f2");
    }
}
