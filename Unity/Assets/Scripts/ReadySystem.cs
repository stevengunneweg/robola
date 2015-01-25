using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class ReadySystem : MonoBehaviour {

	private Choice readyField;
	private bool ready;

	// Use this for initialization
	void Start () {
		ready = false;
		readyField = FindObjectOfType<Choice>();
	}
	
	// Update is called once per frame
	void Update () {
		if(readyField.votes >= 4 && !ready) //Todo: change to 4
		{
			ready = true;
			StartCoroutine(StartGame());
		}
	}

	private IEnumerator StartGame()
	{
		readyField.renderer.material.color = Color.green;

		yield return new WaitForSeconds(1);

		Application.LoadLevel("Menu");
	}
}
