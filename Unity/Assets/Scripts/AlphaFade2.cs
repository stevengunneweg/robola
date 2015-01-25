using UnityEngine;
using System.Collections;

public class AlphaFade2 : MonoBehaviour {
	Color color;// = renderer.material.color;
	float delay = 16;
	bool snd = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	IEnumerator Delay (int time) {
		yield return new WaitForSeconds (time);
	}
	
	void Fade() {
		color = renderer.material.color;
		color.a -= (0.0002f / Time.deltaTime);
		renderer.material.color = color;
	}
	// Update is called once per frame
	void Update () {
		if (delay < 0){
			if (snd == false){
				snd = true;
			}
			Fade();
		} else {
			delay -= 0.001f / Time.deltaTime;
		}
	}
}
