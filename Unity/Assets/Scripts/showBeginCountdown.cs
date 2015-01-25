using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class showBeginCountdown : MonoBehaviour {

	private BeginCountdown _timer;
    private Text _text;

    void Awake()
    {
        _timer = GameObject.Find("GameManager").GetComponent<BeginCountdown>();
        _text = GetComponent<Text>();
    }

    void Update()
    {
        _text.text = _timer.IntroCountDownGet.ToString();
    }
}
