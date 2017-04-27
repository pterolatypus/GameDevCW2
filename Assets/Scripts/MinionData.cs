using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionData {

	private Vector3 startPos;
	private int[] path;

	public MinionData(int x, int y, int[] path) {
		startPos = new Vector3 (x, 0, y);
		this.path = path;
	}

	public Vector3 getStartPos() {
		return startPos;
	}

	public int[] getPath() {
		return path;
	}
}
