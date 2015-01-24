using UnityEngine;
using System.Collections;

public class RowShiftType : GameType {

	private Map map;

	protected void Start () {
		map = FindObjectOfType<Map>();
	}
	
	protected override void UsePowerup(PlayerType player)
	{
		Sound sound = new Sound(transform.root.gameObject.audio, "Sounds/shift sfx");
		Penis closest = map.FindClosest(player.transform.position);
		for (int y = 0; y < map.penisses.GetLength(0); y++) {
			for (int x = 0; x < map.penisses.GetLength(1); x++) {
				if (map.penisses[y, x] == closest) {
					if (Random.value >= 0.5) {
						map.PushRow(y, Map.Direction.Left);
					} else {
						map.PushRow(y, Map.Direction.Right);
					}
				}
			}
		}
	}
}
