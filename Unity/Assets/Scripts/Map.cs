using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour {

	private Penis[,] penisses;
	public enum Direction {
		Up,
		Down,
		Left,
		Right
	}

	// Use this for initialization
	void Start () {
		penisses = new Penis[,] 	{
			{new Penis(0), new Penis(1), new Penis(2)},
			{new Penis(3), new Penis(4), new Penis(5)},
			{new Penis(6), new Penis(7), new Penis(8)}
		};

		Print ();
		PushColumn (1, Direction.Down);
		Print ();
	}

	void Print()
	{
		for(int y = 0; y < penisses.GetLength(1); y++)
		{
			string print = "";
			for(int x = 0; x < penisses.GetLength(0); x++)
			{
				print = print + penisses[y, x].index;
			}

			Debug.Log(print);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void PushRow(int index, Direction direction) {
		if (direction == Direction.Right) {
			Penis temp = penisses[index, penisses.GetLength(1) - 1];
			int pushIndex = penisses.GetLength(1) - 2;
			while(pushIndex >= 0)
			{
				penisses[index, pushIndex+1] = penisses[index, pushIndex]; 
				pushIndex--;
			}
			penisses[index,0] = temp;

		} else if(direction == Direction.Left) {
			Penis temp = penisses[index, 0];
			int pushIndex = 1;
			while(pushIndex != penisses.GetLength(1))
			{
				penisses[index, pushIndex-1] = penisses[index, pushIndex]; 
				pushIndex++;
			}
			penisses[index,penisses.GetLength(1)-1] = temp;

		}
	}
	public void PushColumn(int index, Direction direction) {
		if (direction == Direction.Down) {
			Penis temp = penisses[penisses.GetLength(1) - 1, index];
			int pushIndex = penisses.GetLength(0) - 2;
			while(pushIndex >= 0)
			{
				penisses[pushIndex+1, index] = penisses[pushIndex, index]; 
				pushIndex--;
			}
			penisses[0, index] = temp;
			
		} else if (direction == Direction.Up) {
			Penis temp = penisses[0, index];
			int pushIndex = 1;
			while(pushIndex != penisses.GetLength(0))
			{
				penisses[pushIndex-1, index] = penisses[pushIndex, index]; 
				pushIndex++;
			}
			penisses[penisses.GetLength(0)-1, index] = temp;
			
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
		List<Penis> penissesToRotate;
		if (penisPos.x > 0) { //Left
			penissesToRotate.Add(penisses[penisPos.x - 1, penisPos.y]);
		}
		if (penisPos.y > 0) { //Up
			penissesToRotate.Add(penisses[penisPos.x, penisPos.y - 1]);
		}
		if (penisPos.x < 9) { //Right
			penissesToRotate.Add(penisses[penisPos.x + 1, penisPos.y]);
		}
		if (penisPos.y < 9) { //Down
			penissesToRotate.Add(penisses[penisPos.x, penisPos.y + 1]);
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
		List<Penis> penissesToRotate;
		if (penisPos.x > 0) { //Left
			penissesToRotate.Add(penisses[penisPos.x - 1, penisPos.y]);
		}
		if (penisPos.y > 0) { //Up
				penissesToRotate.Add(penisses[penisPos.x, penisPos.y - 1]);
		}
		if (penisPos.x < 9) { //Right
			penissesToRotate.Add(penisses[penisPos.x + 1, penisPos.y]);
		}
		if (penisPos.y < 9) { //Down
			penissesToRotate.Add(penisses[penisPos.x, penisPos.y + 1]);
		}
		Penis temp = penissesToRotate[0];
		for (int i = 1; i < penissesToRotate.Count; i++) {
			penissesToRotate[i - 1] = penissesToRotate[i];
		}
		penissesToRotate[penissesToRotate.Count - 1] = temp;
	}
}
