using UnityEngine;
using System.Collections;

public class SwitchWithRandomOtherPlayerType : GameType
{
    private PlayerType[] playerTypes;
    private PlayerType unluckyPerson; int person;
    private ArrayList nonInfectedPlayers = new ArrayList();
    private Vector3 playerPos, unluckyBastardsPos;


    protected override void UsePowerup(PlayerType player)
    {
        SwitchWithUnluckyBastard(player, unluckyPersonToSwitchWith(player));
    }

    PlayerType unluckyPersonToSwitchWith(PlayerType player)
    {
        playerTypes = FindObjectsOfType<PlayerType>();

        foreach (PlayerType type in playerTypes)
        {
            if (!type.infected && type != player)
            {
                nonInfectedPlayers.Add(type);
            }
        }

        person = Random.Range(0, nonInfectedPlayers.Count);
        unluckyPerson = nonInfectedPlayers[person] as PlayerType;
        return unluckyPerson;
    }

    void SwitchWithUnluckyBastard(PlayerType player, PlayerType unluckyBastard)
    {
        playerPos = player.transform.position;
        unluckyBastardsPos = unluckyBastard.transform.position;

        player.transform.position = unluckyBastardsPos;
        unluckyBastard.transform.position = playerPos;
    }
}
