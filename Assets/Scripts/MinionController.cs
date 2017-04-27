using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : MonoBehaviour {

	public int[] path;
	public int pathcounter = 0;
	private float lastMove;
	public float moveDelay = 0.1f;
	public float speed = 1.0f;
	public float targetX, targetY;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (path.Length > 0) {
			doMove ();
		}
	}

	public void setup(MinionData data) {
		this.path = data.getPath ();
		this.GetComponent<Transform> ().position = data.getStartPos ();
		targetX = data.getStartPos().x;
		targetY = data.getStartPos().z;
	}

	void doMove() {
		Transform t = this.GetComponent<Transform> ();
		Rigidbody r = this.GetComponent<Rigidbody> ();
		if (Math.Abs(t.position.x - targetX) < 0.05 && Math.Abs(t.position.z - targetY) < 0.05) {

			r.velocity = new Vector3 (0, r.velocity.y, 0);
			t.position = new Vector3(targetX, t.position.y, targetY);

			int dir = path [pathcounter];
			pathcounter = (pathcounter + 1) % path.Length;
			beginMove (dir);

		} else {
			if (t.position.x > targetX) {
				r.velocity = new Vector3 (-1f, 0, 0)*speed;
			} else if (t.position.x < targetX) {
				r.velocity = new Vector3 (1f, 0, 0)*speed;
			}
			if (t.position.z > targetY) {
				r.velocity = new Vector3 (0, 0, -1f)*speed;
			} else if (t.position.z < targetY) {
				r.velocity = new Vector3 (0, 0, 1f)*speed;
			}
		}
	}

	void beginMove(int direction) {
		Debug.Log ("Minion moving in direction: " + direction);
		Transform t = this.GetComponent<Transform> ();
		t.eulerAngles = new Vector3 (0, 0, 0);
		t.Rotate (new Vector3(0, direction*90, 0));
		switch (direction) {
			case 0:
				targetY++;
				break;
			case 1:
				targetX++;
				break;
			case 2:
				targetY--;
				break;
			case 3:
				targetX--;
				break;
		}

	}
}
