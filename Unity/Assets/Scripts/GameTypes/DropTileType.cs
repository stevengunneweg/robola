using UnityEngine;
using System.Collections;

public class DropTileType : GameType {
    
    public GameObject tile;

    protected override void UsePowerup(PlayerType player)
    {
		Sound sound = new Sound(transform.root.gameObject.audio, "Sounds/tile sfx");
        StartCoroutine(TileDrop(player));
    }

    public IEnumerator TileDrop(PlayerType currentPlayer)
    {
        GameObject tileDrop = Instantiate(tile, currentPlayer.transform.position, transform.rotation) as GameObject;
        yield return new WaitForSeconds(3);
        Destroy(tileDrop);
    }
}
