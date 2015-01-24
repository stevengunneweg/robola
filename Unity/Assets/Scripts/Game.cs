using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	private GameType type;
	private List<object> players;
	private	float time;

	public GameObject InfectorWinPanel;
	public GameObject PlayerWinPanel;

	void Update () {
		GameObject.Find("GameTimer").GetComponent<Text>().text = time.ToString("f2");
		if(FindObjectsOfType<PlayerType>().Where(p => !p.infected).ToList().Count == 0)
		{
			StartCoroutine(ShowInfectorWin());
		}
	}

	private IEnumerator ShowInfectorWin()
	{
		yield return new WaitForSeconds(1);
		InfectorWinPanel.SetActive(true);
	}

	private IEnumerator ShowPlayerWin()
	{
		yield return new WaitForSeconds(1);
		PlayerWinPanel.SetActive(true);
	}
}
