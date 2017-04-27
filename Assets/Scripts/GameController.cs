using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private int[,] level1 = {
		{1, 1, 1, 1},
		{1, 0, 1, 1},
		{1, 1, 1, 1}
	};
	private int[,] level2, level3, level4;

	private int stage;

	public GameObject[] boardTiles;
	public GameObject minionObj;

	//3 integers (1 per goat)
	// 0 - not yet played
	// 1 - failed
	// 2 - completed & banked
	// 3 - completed & waiting
	private int[] goatState;

	// Use this for initialization
	void Start () {
		generateBoard(level1);
		MinionData dat = new MinionData(0, 0, new int[] {0, 0, 1, 1, 2, 2, 3, 3});
		GameObject minion = GameObject.Instantiate (minionObj, new Vector3 (0, 0, 0), Quaternion.identity);
		minion.GetComponent<MinionController>().setup (dat);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void setStage(int newStage) {

	}

	void generateBoard(int[,] board) {
		for (int y = 0; y < board.GetLength(0); y++) {
			for (int x = 0; x < board.GetLength(1); x++) {
				int tileType = board [y,x];
				placeTile (x, y, tileType);
			}
		}
	}

	void placeTile(int x, int y, int tile) {
		if (tile > 0 && tile < boardTiles.Length) {
			Instantiate (boardTiles[tile], new Vector3(x, 0, y), Quaternion.identity);
		}
	}

	void clear() {

	}
}
