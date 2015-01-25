using UnityEngine;
using System.Collections;

public class BlinkType : GameType {
    private TrailRenderer TR;
    private ParticleSystem PS;

    protected override void UsePowerup(PlayerType player)
    {
        TR = player.GetComponent<TrailRenderer>();
        StartCoroutine(trail(player));
		Sound sound = new Sound(transform.root.gameObject.audio, "Sounds/blink sfx");
    }

    IEnumerator trail(PlayerType player)
    {
        TR.enabled = true;
        player.transform.position += (player.player.input * 5);
        yield return new WaitForSeconds(2f);
        TR.enabled = false;
    }
}
