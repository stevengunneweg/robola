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

    protected virtual void Start()
    {
        players = FindObjectsOfType<PlayerType>();
    }

    protected virtual void Update()
    {
        foreach (PlayerType player in players)
        {
            if (!player.infected)
            {
                if (Input.GetKeyDown(player.actionButton))
                {
                    Debug.Log("test");
                    UsePowerup(player);
                }
            }
        }
        
    }

    protected virtual void UsePowerup(PlayerType player)
    {
    }
}

