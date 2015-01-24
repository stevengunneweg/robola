using UnityEngine;
using System.Collections;
using System.Linq;

public class VoteSystem : MonoBehaviour {

	public TextMesh mesh;

	private Choice[] choices;

	private float timer;
	private bool done;

	// Use this for initialization
	void Start () {
		done = false;
		timer = 10;
		choices = FindObjectsOfType<Choice>();
	}
	
	// Update is called once per frame
	void Update () {
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

		yield return new WaitForSeconds(1);

		Application.LoadLevel("Game");
	}
}
