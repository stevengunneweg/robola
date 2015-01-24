using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	private GameType type;
	private List<object> players;
	private	float time;
	private object map;

	// Use this for initialization
	void Start () {
        GameType[] gametypes = FindObjectsOfType<GameType>();

        gametypes[0].enabled = true;
	}
	
	// Update is called once per frame

	void Update () {
	
	}
}
