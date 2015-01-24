using UnityEngine;
using System.Collections;

public class VoteSystem : MonoBehaviour {

	private Choice[] choices;

	// Use this for initialization
	void Start () {
		choices = FindObjectsOfType<Choice>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
