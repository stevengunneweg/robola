using System;
using System.Collections.Generic;
using UnityEngine;

public class GameType : MonoBehaviour
{
    public string TypeName;
    public float Cooldown,Duration;

    private PlayerType[] players;

    private void Awake()
    {
        enabled = false;
    }
    

    protected virtual void Update()
	{
		players = FindObjectsOfType<PlayerType>();

		foreach (PlayerType player in players)
		{
			if (!player.infected)
			{
				if (Input.GetKeyDown(player.actionButton) && player.cooldown <= 0)
				{
					player.cooldown = this.Cooldown;
                    player.duration = this.Duration;
                    UsePowerup(player);
                }
            }
        }
        
    }

    protected virtual void UsePowerup(PlayerType player)
    {
    }
}

