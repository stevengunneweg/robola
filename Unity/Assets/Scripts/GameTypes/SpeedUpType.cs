using UnityEngine;
using System.Collections;

public class SpeedUpType : GameType
{
    protected override void UsePowerup(PlayerType player)
	{
		Sound sound = new Sound(transform.root.gameObject.audio, "Sounds/speed sfx");
        player.uninfectedSpeed = 150;
    }
}
