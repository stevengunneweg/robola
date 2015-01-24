using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	private GameType type;
	private List<object> players;
	//private	float time;

	public GameObject InfectorWinPanel;
	public GameObject PlayerWinPanel;

	public bool soundPlayed = false;

	void Update () {
		//GameObject.Find("GameTimer").GetComponent<Text>().text = time.ToString("f2");
		if(FindObjectsOfType<PlayerType>().Where(p => !p.infected).ToList().Count == 0)
		{
			StartCoroutine(ShowInfectorWin());
		}
	}

	private void PlaySound(){
		if (!soundPlayed){
			soundPlayed = true;
			Sound sound = new Sound(transform.root.gameObject.audio, "Voice/game over");
		}
	}

	private IEnumerator ShowInfectorWin()
	{
		yield return new WaitForSeconds(1);
		PlaySound();
		InfectorWinPanel.SetActive(true);
	}

	private IEnumerator ShowPlayerWin()
	{
		yield return new WaitForSeconds(1);
		PlaySound();
		PlayerWinPanel.SetActive(true);
	}
}
