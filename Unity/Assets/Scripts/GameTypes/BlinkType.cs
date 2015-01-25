using UnityEngine;
using System.Collections;

public class BlinkType : GameType {

    protected override void UsePowerup(PlayerType player)
    {
		player.transform.position += (player.player.input * 5);
		Sound sound = new Sound(transform.root.gameObject.audio, "Sounds/blink sfx");
    }
}
