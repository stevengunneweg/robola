using UnityEngine;
using System.Collections;

public class BlinkType : GameType {

    protected override void UsePowerup(PlayerType player)
    {
        player.transform.position += (player.player.input * 50);
    }
}
