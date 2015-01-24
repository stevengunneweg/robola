using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Game : MonoBehaviour {

	private GameType type;
	private List<object> players;
	private	float time;

	// Use this for initialization
	void Start () {
        GameType[] gametypes = FindObjectsOfType<GameType>();

		int index = Random.Range(0, gametypes.Length-1);
		gametypes[index].enabled = true;
	}

	void Update () {
		if(FindObjectsOfType<PlayerType>().Where(p => !p.infected).ToList().Count == 0)
		{
			Application.LoadLevel("Menu");
		}
	}
}
