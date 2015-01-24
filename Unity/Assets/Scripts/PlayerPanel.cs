using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour {

	public PlayerType player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(player.infected)
		{
			GetComponent<Image>().color = Color.green;
		}
	}
}
