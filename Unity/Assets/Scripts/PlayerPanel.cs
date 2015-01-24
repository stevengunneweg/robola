using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour {

	public PlayerType player;

	// Use this for initialization
	void Start () {
		Text text = transform.FindChild("Text").GetComponent<Text>();
		text.text = "Player " + player.player.playerNumber;
	}
	
	// Update is called once per frame
	void Update () {
		if(player.infected)
		{
			GetComponent<Image>().color = Color.green;
		}

		Text cooldownText = transform.FindChild("Cooldown").GetComponent<Text>();
		if (player.cooldown > 0 && !player.infected) {
			GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0.4f);
			cooldownText.text = "Cooldown: " + player.cooldown.ToString ("f1");
		} else {
			GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1);
			cooldownText.text = "";
		}
	}
}
