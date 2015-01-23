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
}
