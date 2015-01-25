using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	private GameType type;
	private List<object> players;
    
    private PlayerType[] playerTypes;
    private PlayerType infectedPerson; int randomPlayer;
	//private	float time;

	public GameObject InfectorWinPanel;
	public GameObject PlayerWinPanel;

	public bool soundPlayed = false;
    void Start()
    {
        playerTypes = FindObjectsOfType<PlayerType>();
        randomPlayer = Random.Range(0, 4);
        infectedPerson = playerTypes[randomPlayer] as PlayerType;
        infectedPerson.infected = true;

    }

	void Update () {
		//GameObject.Find("GameTimer").GetComponent<Text>().text = time.ToString("f2");
		if(FindObjectsOfType<PlayerType>().Where(p => !p.infected).ToList().Count == 0)
		{
            FindObjectOfType<RoundTimer>().StopCountDown();
			//StartCoroutine(ShowInfectorWin());
		}
		if (FindObjectOfType<RoundTimer> ().time <= 0) {
            FindObjectOfType<RoundTimer>().StopCountDown();
			//StartCoroutine(ShowPlayerWin());
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
		yield return new WaitForSeconds(5);
        clearPowerUps();
		Application.LoadLevel("Menu");
	}

	private IEnumerator ShowPlayerWin()
	{
		yield return new WaitForSeconds(1);
		PlaySound();
		PlayerWinPanel.SetActive(true);
		yield return new WaitForSeconds(5);
        clearPowerUps();
		Application.LoadLevel("Menu");
	}

    void clearPowerUps()
    {
        List<GameType> types = FindObjectsOfType<GameType>().ToList();
        foreach (GameType type in types)
        {
            type.enabled = false;
        }
    }
}
