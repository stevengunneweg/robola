using UnityEngine;
using System.Collections;

public class DropTileType : GameType {
    
    public GameObject tile;
    ParticleSystem particles;

    protected override void UsePowerup(PlayerType player)
    {
        particles = player.GetComponent<ParticleSystem>();
		Sound sound = new Sound(transform.root.gameObject.audio, "Sounds/tile sfx");
        StartCoroutine(TileDrop(player));
    }

    public IEnumerator TileDrop(PlayerType currentPlayer)
    {
        particles.startColor = Color.red;
        particles.Emit(2);
        GameObject tileDrop = Instantiate(tile, currentPlayer.transform.position, transform.rotation) as GameObject;
        yield return new WaitForSeconds(3);
        Destroy(tileDrop);
    }
}
