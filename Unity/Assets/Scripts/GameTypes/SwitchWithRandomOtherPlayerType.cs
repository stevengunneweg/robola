using UnityEngine;
using System.Collections;

public class SwitchWithRandomOtherPlayerType : GameType
{
    private PlayerType[] playerTypes;
    private PlayerType unluckyPerson; int person;
    private ArrayList nonInfectedPlayers = new ArrayList();
    private Vector3 playerPos, unluckyBastardsPos;
    private ParticleSystem PS;


    protected override void UsePowerup(PlayerType player)
	{
        nonInfectedPlayers.Clear();
        PS = player.GetComponent<ParticleSystem>();
        SwitchWithUnluckyBastard(player, unluckyPersonToSwitchWith(player));
		Sound sound = new Sound(transform.root.gameObject.audio, "Sounds/shift sfx");
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

        if (nonInfectedPlayers.Count >= 1)
        {
            person = Random.Range(0, nonInfectedPlayers.Count);
            unluckyPerson = nonInfectedPlayers[person] as PlayerType;
            return unluckyPerson;
        }
        else
        {
            return null;
        }
    }

    void SwitchWithUnluckyBastard(PlayerType player, PlayerType unluckyBastard)
    {
        StartCoroutine(Particles(player, unluckyBastard));
    }

    IEnumerator Particles(PlayerType player, PlayerType unluckyBastard)
    {
        Debug.Log("test");
        PS.startColor = new Color32(64, 179, 255, 255);
        PS.startSize = 5f;
        PS.startLifetime = 1f;
        PS.Emit(15);
        unluckyBastard.GetComponent<ParticleSystem>().startColor = new Color32(246, 129, 51, 255);
        unluckyBastard.GetComponent<ParticleSystem>().startSize = 5f;
        unluckyBastard.GetComponent<ParticleSystem>().startLifetime = 1f;
        unluckyBastard.GetComponent<ParticleSystem>().Emit(15);
        yield return new WaitForSeconds(.4f);
        playerPos = player.transform.position;
        unluckyBastardsPos = unluckyBastard.transform.position;

        player.transform.position = unluckyBastardsPos;
        unluckyBastard.transform.position = playerPos;
    }
}
