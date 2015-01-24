using UnityEngine;
using System.Collections;

public class ReverserInfectedType : GameType
{

    private PlayerType[] playerTypes;
    protected override void UsePowerup(PlayerType player)
    {
        playerTypes = FindObjectsOfType<PlayerType>();
        foreach (PlayerType type in playerTypes)
        {
            if (type.infected)
            {
                type.infectedSpeed = -type.infectedSpeed;
                type.duration = Duration;
            }
        }
    }
}
