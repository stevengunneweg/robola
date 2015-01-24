using UnityEngine;
using System.Collections;

public class PenisRotateType : GameType {

	private Map map;

	protected void Start () {
		map = FindObjectOfType<Map>();
	}
	
	protected override void UsePowerup(PlayerType player)
	{
		Penis closest = map.FindClosest(player.transform.position);
		for (int y = 0; y < map.penisses.GetLength(0); y++) {
			for (int x = 0; x < map.penisses.GetLength(1); x++) {
				if (map.penisses[y, x] == closest) {
					Debug.Log ("x:"+x+", y:"+y);
					
					//Todo: get correct penis to rotate around
					//Todo: move correct penisses
					//Todo: rotate penis

					//if (Random.value >= 0.5) {
						map.RotatePenissesAroundPenisCW(closest);
					//} else {
					//	map.RotatePenissesAroundPenisCCW(closest);
					//}
				}
			}
		}
	}
}
