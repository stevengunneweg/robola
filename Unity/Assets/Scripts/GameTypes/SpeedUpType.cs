using UnityEngine;
using System.Collections;

public class SpeedUpType : GameType
{
    protected override void UsePowerup(PlayerType player)
    {
        player.uninfectedSpeed = 150;
    }
}
