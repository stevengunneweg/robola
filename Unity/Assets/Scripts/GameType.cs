using System;
using UnityEngine;

public abstract class GameType
{
	public GameType ()
	{
	}

	public Vector3 Gravity;
	public int PlayerBaseSpeed;
	public int InfectedBaseSpeed;

	public virtual void OnPlayerCaptured(object player) {};
	public virtual void OnPlayerCollideTile(object player, object tile) {};
	public virtual void Update() {};
}

