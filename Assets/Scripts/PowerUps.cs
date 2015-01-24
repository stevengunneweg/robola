using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {

	///<summary>
    /// collection of all the possible power ups
    ///</summary>
    public GameObject tile;
    public int currentPowerUp;

    public void Blink(Rigidbody player, Vector3 input)
    {
        player.AddForce(input * 100000);
    }

    public void TileDrop(Rigidbody player)
    {
        GameObject tileDrop = Instantiate(tile, player.transform.position, transform.rotation) as GameObject;
    }
}
