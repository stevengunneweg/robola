using UnityEngine;
using System.Collections;

public class TeleportType : GameType {

	private Map map;
    private TrailRenderer TR;
    private ParticleSystem PS;

	protected void Start () {
	}
	
	protected override void UsePowerup(PlayerType player)
	{
		Sound sound = new Sound(transform.root.gameObject.audio, "Sounds/teleport sfx");
		float yPos = player.transform.position.y;
        Vector3 newPos = FindObjectOfType<Map>().RandomPenis().transform.position;
        TR = player.GetComponent<TrailRenderer>();
        PS = player.GetComponent<ParticleSystem>();
        
        StartCoroutine(trail(newPos, yPos, player));

		//Todo: check if penis is occupied

		
        
	}

    IEnumerator trail(Vector3 newPos, float yPos, PlayerType player)
    {
      
        TR.enabled = true;
        PS.Emit(30);
        yield return new WaitForSeconds(.3f);
        player.transform.position = new Vector3(newPos.x, yPos, newPos.y);
        yield return new WaitForSeconds(1f);
        TR.enabled = false;
    }
}
