using UnityEngine;
using System.Collections;

public class SwitchWithInfectedFurthestAwayType : GameType
{
    private PlayerType[] playerTypes;
    private PlayerType farAway;
    private float currentDistance;
    private Vector3 playerPos, infectedPos;

    protected override void UsePowerup(PlayerType player)
    {
        SwitchWithInfected(player, FurthestAway(player));
    }

    PlayerType FurthestAway(PlayerType player)
    {
        playerTypes = FindObjectsOfType<PlayerType>();
        farAway = null;
        currentDistance = float.MinValue;

        foreach(PlayerType type in playerTypes)
        {
            if (type.infected)
            {
                float distance = Vector3.Distance(player.transform.position, type.transform.position);
                if (distance > currentDistance)
                {
                    currentDistance = distance;
                    farAway = type;
                }
            }
        }
        return farAway;
    }

    void SwitchWithInfected(PlayerType player, PlayerType infected)
    {
        playerPos = player.transform.position;
        infectedPos = infected.transform.position;

        player.transform.position = infectedPos;
        infected.transform.position = playerPos;
    }
}
