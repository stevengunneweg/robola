using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class VoteSystem : MonoBehaviour {

	public TextMesh mesh;

	private Choice[] choices;

	private float timer;
	private bool done;

	private int prevTime = 0;

	// Use this for initialization
	void Start () {
		done = false;
		timer = 10;
		choices = FindObjectsOfType<Choice>();
		List<GameType> types = FindObjectsOfType<GameType>().ToList ();

		foreach(Choice choice in choices)
		{
			int index = Random.Range (0, types.Count-1);
			choice.type = types[index];
			types.Remove(choice.type);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Mathf.Ceil(timer) < 4 && prevTime != Mathf.Ceil(timer)){
			prevTime = (int)Mathf.Ceil(timer);
			Sound sound = new Sound(transform.root.gameObject.audio, "Voice/" + prevTime);
		}
		if(timer >= 0)
		{
			timer -= Time.deltaTime;
		}
		else {
			if(!done)
			{
				done = true;
				StartCoroutine(StartGame());
			}
			timer = 0;
		}

		mesh.text = timer.ToString("f1");


	}

	private IEnumerator StartGame()
	{
		Choice chosen = choices.OrderByDescending(c => c.votes).First();
		chosen.renderer.material.color = Color.green;

		chosen.type.enabled = true;

		yield return new WaitForSeconds(1);

		Application.LoadLevel("Game");
	}
}
