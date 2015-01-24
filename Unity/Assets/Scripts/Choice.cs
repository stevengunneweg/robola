using UnityEngine;
using System.Collections;

public class Choice : MonoBehaviour {

	private GameType _type;
	public GameType type {
		get {
			return _type;
		} 
		set {
			_type = value;
			transform.FindChild("Label").GetComponent<TextMesh>().text = _type.TypeName;

		}
	}
	public int votes;

	void OnTriggerEnter(Collider other)
	{
		Sound sound = new Sound(transform.root.gameObject.audio, "Sounds/vote");
		if(other.tag == "Player")
			votes++;
		
		UpdateString();
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
			votes--;

		UpdateString();
	}

	private void UpdateString()
	{
		string voteString = "";
		for(int i = 0; i < votes; i++)
		{
			voteString += " X";
		}
		transform.FindChild("Votes").GetComponent<TextMesh>().text = voteString;
	}
}
