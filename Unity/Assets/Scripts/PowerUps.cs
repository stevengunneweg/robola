using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {

	///<summary>
    /// collection of all the possible power ups
    ///</summary>

    public int currentPowerUp;

    public void Blink(Rigidbody player, Vector3 input)
    {
        player.AddForce(input * 100000);
    }
}
