using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class Map : MonoBehaviour {

	public const int MAP_WIDTH = 9;
	public const int MAP_HEIGHT = 9;
	public const int PENIS_SIZE = 40;

	private Penis[,] penisses;

	public enum Direction {
		Up,
		Down,
		Left,
		Right
	}

	// Use this for initialization
	void Start () {

		penisses = new Penis[MAP_HEIGHT, MAP_WIDTH];

		Penis smallest = null;
		float smallestDistance = float.MaxValue;
		foreach(Penis penis in FindObjectsOfType<Penis>())
		{
			float distance = penis.transform.position.x + penis.transform.position.z;
			if(distance < smallestDistance)
			{
				smallestDistance = distance;
				smallest = penis;
			}
		}

		Penis current = smallest;
		Penis next = null;
		int ding = 0;

		for(int y = 0; y < MAP_HEIGHT; y++)
		{
			for(int x = 0; x < MAP_WIDTH; x++)
			{
				penisses[x, y] = current;
				current = FindClosest(current.transform.position + new Vector3(PENIS_SIZE, 0, 0));
			}

			current = FindClosest(penisses[0, y].transform.position + new Vector3(0, 0, PENIS_SIZE));
		}

		PushColumn(3, Direction.Down);
	}

	private Penis FindClosest(Vector3 position)
	{
		Penis closest = null;
		float smallestDistance = float.MaxValue;

		foreach(Penis penis in FindObjectsOfType<Penis>())
		{	
			float distance = (penis.transform.position - position).sqrMagnitude;
			if(distance < smallestDistance)
			{
				closest = penis;
				smallestDistance = distance;
			}
		}

		return closest;
	}

	void Print()
	{
		for(int y = 0; y < penisses.GetLength(1); y++)
		{
			string print = "";
			for(int x = 0; x < penisses.GetLength(0); x++)
			{
				//print = print + penisses[y, x].index;
			}

			Debug.Log(print);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void PushRow(int index, Direction direction) {
		List<PenisMovement> movements = new List<PenisMovement>();

		if (direction == Direction.Right) {
			Penis temp = penisses[index, penisses.GetLength(1) - 1];
			int pushIndex = penisses.GetLength(1) - 2;
			while(pushIndex >= 0)
			{
				movements.Add (new PenisMovement(penisses[index,pushIndex], penisses[index,pushIndex+1].transform.position));
				penisses[index, pushIndex+1] = penisses[index, pushIndex]; 
				pushIndex--;
			}

			movements.Add (new PenisMovement(temp, penisses[index, 0].transform.position, true));

			penisses[index,0] = temp;

		} else if(direction == Direction.Left) {
			Penis temp = penisses[index, 0];
			int pushIndex = 1;
			while(pushIndex != penisses.GetLength(1))
			{
				movements.Add (new PenisMovement(penisses[index,pushIndex], penisses[index,pushIndex-1].transform.position));
				penisses[index, pushIndex-1] = penisses[index, pushIndex]; 
				pushIndex++;
			}

			movements.Add (new PenisMovement(temp, penisses[index,penisses.GetLength(1)-1].transform.position, true));

			penisses[index,penisses.GetLength(1)-1] = temp;
		}

		MovePenis(movements);
	}
	public void PushColumn(int index, Direction direction) {
		
		List<PenisMovement> movements = new List<PenisMovement>();

		if (direction == Direction.Down) {
			Penis temp = penisses[penisses.GetLength(1) - 1, index];
			int pushIndex = penisses.GetLength(0) - 2;
			while(pushIndex >= 0)
			{
				movements.Add (new PenisMovement(penisses[pushIndex, index], penisses[pushIndex+1, index].transform.position));
				penisses[pushIndex+1, index] = penisses[pushIndex, index];
				pushIndex--;
			}
			
			movements.Add (new PenisMovement(temp, penisses[0, index].transform.position, true));

			penisses[0, index] = temp;
			
		} else if (direction == Direction.Up) {
			Penis temp = penisses[0, index];
			int pushIndex = 1;
			while(pushIndex != penisses.GetLength(0))
			{
				movements.Add (new PenisMovement(penisses[pushIndex, index], penisses[pushIndex-1, index].transform.position));

				penisses[pushIndex-1, index] = penisses[pushIndex, index]; 
				pushIndex++;
			}
			
			movements.Add (new PenisMovement(temp, penisses[penisses.GetLength(0)-1, index].transform.position, true));
			penisses[penisses.GetLength(0)-1, index] = temp;

		}

		MovePenis(movements);
	}

	private void MovePenis(List<PenisMovement> movements)
	{
		foreach(PenisMovement move in movements)
		{
			LeanTween.move(move.penis.gameObject, move.target, 1f).setDelay(1f);
		}
	}

	class PenisMovement
	{
		public Penis penis;
		public Vector3 target;
		public bool special;

		public PenisMovement(Penis penis, Vector3 target): 
			this(penis, target, false)
		{
		}

		public PenisMovement(Penis penis, Vector3 target, bool special)
		{
			this.penis = penis;
			this.target = target;
			this.special = special;
		}
	}

	public Vector2 GetPenisPostition(Penis penis) {
		for(int y = 0; y < penisses.GetLength(1); y++) {
			for(int x = 0; x < penisses.GetLength(0); x++) {
				if (penisses[y, x] == penis) {
					return new Vector2(x, y);
				}
			}
		}
		return new Vector2(-1, -1);
	}
	
	
	public void RotatePenissesAroundPenisCW(Penis penis) {
		Vector2 penisPos = GetPenisPostition (penis);
		if (penisPos.Equals(new Vector2(-1, -1))) {
			return;
		}
		List<Penis> penissesToRotate = new List<Penis>();
		if ((int)penisPos.x > 0) { //Left
			penissesToRotate.Add(penisses[(int)penisPos.x - 1, (int)penisPos.y]);
		}
		if ((int)penisPos.y > 0) { //Up
			penissesToRotate.Add(penisses[(int)penisPos.x, (int)penisPos.y - 1]);
		}
		if ((int)penisPos.x < 9) { //Right
			penissesToRotate.Add(penisses[(int)penisPos.x + 1, (int)penisPos.y]);
		}
		if ((int)penisPos.y < 9) { //Down
			penissesToRotate.Add(penisses[(int)penisPos.x, (int)penisPos.y + 1]);
		}
		Penis temp = penissesToRotate[penissesToRotate.Count - 1];
		for (int i = penissesToRotate.Count - 2; i >= 0; i--) {
			penissesToRotate[i + 1] = penissesToRotate[i];
		}
		penissesToRotate[0] = temp;
	}

	public void RotatePenissesAroundPenisCCW(Penis penis) {
		Vector2 penisPos = GetPenisPostition (penis);
		if (penisPos.Equals(new Vector2(-1, -1))) {
			return;
		}
		List<Penis> penissesToRotate = new List<Penis>();
		if ((int)penisPos.x > 0) { //Left
			penissesToRotate.Add(penisses[(int)penisPos.x - 1, (int)penisPos.y]);
		}
		if ((int)penisPos.y > 0) { //Up
				penissesToRotate.Add(penisses[(int)penisPos.x, (int)penisPos.y - 1]);
		}
		if ((int)penisPos.x < 9) { //Right
			penissesToRotate.Add(penisses[(int)penisPos.x + 1, (int)penisPos.y]);
		}
		if ((int)penisPos.y < 9) { //Down
			penissesToRotate.Add(penisses[(int)penisPos.x, (int)penisPos.y + 1]);
		}
		Penis temp = penissesToRotate[0];
		for (int i = 1; i < penissesToRotate.Count; i++) {
			penissesToRotate[i - 1] = penissesToRotate[i];
		}
		penissesToRotate[penissesToRotate.Count - 1] = temp;
	}
}
