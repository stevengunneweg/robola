using UnityEngine;
using System.Collections;

public class BlinkType : GameType {

    protected override void UsePowerup(PlayerType player)
    {
        player.rigidbody.AddForce(player.player.input * 100000);
    }
}
