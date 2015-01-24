using UnityEngine;
using System.Collections;

public class DropTileType : GameType {
    
    public GameObject tile;
    ParticleSystem particles;

    protected override void UsePowerup(PlayerType player)
    {
<<<<<<< HEAD
        particles = player.GetComponent<ParticleSystem>();
=======
		Sound sound = new Sound(transform.root.gameObject.audio, "Sounds/tile sfx");
>>>>>>> d8557b462e6992fc7529c6d9e18675514d95ebf1
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
