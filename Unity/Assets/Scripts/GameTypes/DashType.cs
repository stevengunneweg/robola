using UnityEngine;
using System.Collections;

public class DashType : GameType {

    public float multiplier;
    
    protected override void UsePowerup(PlayerType player)
    {
        player.uninfectedSpeed = player.uninfectedSpeed * multiplier;
		Sound sound = new Sound(transform.root.gameObject.audio, "Sounds/dash sfx");
    }
}
