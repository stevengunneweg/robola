using UnityEngine;
using System.Collections;

public class SpeedUpType : GameType
{
    private TrailRenderer trail;
    protected override void UsePowerup(PlayerType player)
	{
		Sound sound = new Sound(transform.root.gameObject.audio, "Sounds/speed sfx");
        trail = player.GetComponent<TrailRenderer>();
        StartCoroutine(GottaGoFast(player));
        player.uninfectedSpeed = 12;        
    }

    IEnumerator GottaGoFast(PlayerType player)
	{        
		Sound sound = new Sound(transform.root.gameObject.audio, "Sounds/speed sfx");
        trail.enabled = true;
        yield return new WaitForSeconds(player.duration);
        trail.enabled = false;
    }
}
