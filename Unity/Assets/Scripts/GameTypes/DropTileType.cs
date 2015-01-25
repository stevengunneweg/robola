using UnityEngine;
using System.Collections;

public class DropTileType : GameType {
    
    public GameObject tile;
    ParticleSystem particles;

    protected override void UsePowerup(PlayerType player)
	{
        tile = Resources.Load("Tile") as GameObject;
        particles = player.GetComponent<ParticleSystem>();
	    StartCoroutine(TileDrop(player));
    }

    public IEnumerator TileDrop(PlayerType currentPlayer)
	{
		Sound sound = new Sound(transform.root.gameObject.audio, "Sounds/tile sfx");
        particles.startColor = Color.red;
        particles.Emit(2);
        GameObject tileDrop = Instantiate(tile, currentPlayer.transform.position, Quaternion.EulerAngles(currentPlayer.transform.rotation.eulerAngles.x, currentPlayer.transform.rotation.eulerAngles.y + 180, currentPlayer.transform.rotation.eulerAngles.z)) as GameObject;
        yield return new WaitForSeconds(3);
        Destroy(tileDrop);
    }
}
