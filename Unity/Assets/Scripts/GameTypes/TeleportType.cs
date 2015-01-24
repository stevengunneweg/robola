using UnityEngine;
using System.Collections;

public class TeleportType : GameType {

	private Map map;

	protected override void Start () {
		base.Start ();
		map = FindObjectOfType<Map>();
	}
	
	protected override void UsePowerup(PlayerType player)
	{
		float yPos = player.transform.position.y;
		Vector3 newPos = map.RandomPenis ().transform.position;

		//Todo: check if penis is occupied

		player.transform.position = new Vector3(newPos.x, yPos, newPos.y);
	}
}
