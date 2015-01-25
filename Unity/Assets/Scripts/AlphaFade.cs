using UnityEngine;
using System.Collections;

public class AlphaFade : MonoBehaviour {
	Color color;// = renderer.material.color;
	float delay = 8;
	bool snd = false;

	// Use this for initialization
	void Start () {
	
	}

	IEnumerator Delay (int time) {
		yield return new WaitForSeconds (time);
	}

	void Fade() {
		color = renderer.material.color;
		color.a += (0.001f / Time.deltaTime);
		renderer.material.color = color;
	}
	void PlaySnd(){
		Sound sound = new Sound(transform.root.gameObject.audio, "Sounds/speed sfx");
	}
	// Update is called once per frame
	void Update () {
		if (delay < 0){
			if (snd == false){
				PlaySnd();
				snd = true;
			}
			Fade();
		} else {
			delay -= 0.001f / Time.deltaTime;
		}

		if(color.a > 19){
			Application.LoadLevel("Ready");
		}
	}
}
