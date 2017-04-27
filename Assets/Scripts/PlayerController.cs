using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private int size = 2, lives = 3;
	private bool[] sizes = {true, true, true};
	private float lastAbility;
	public float targetX = 0f, targetY = 0f;
	public float speed = 1.0f;
	private GoatAttributes activeGoat;
	public GoatAttributes[] goats;

	// Use this for initialization
	void Start () {
		switchTo (0);
		goats [0].setAbility (new AbilityDash());
	}
	
	// Update is called once per frame
	void Update () {
		doMovement ();
		doCharSwitch ();
		doAbility ();
	}


	void doAbility() {
		if (Time.time > lastAbility + activeGoat.abilityCooldown()) {
			if (Input.GetButtonDown ("FireUp")) {
				activeGoat.useAbility (0, this);
			}
			if (Input.GetButtonDown ("FireRight")) {
				activeGoat.useAbility (1, this);
			}
			if (Input.GetButtonDown ("FireDown")) {
				activeGoat.useAbility (2, this);
			}
			if (Input.GetButtonDown ("FireLeft")) {
				activeGoat.useAbility (3, this);
			}
		}
	}

	void doMovement() {

		Transform t = this.GetComponent<Transform> ();
		Rigidbody r = this.GetComponent<Rigidbody> ();
		Rigidbody pr = t.parent.GetComponent<Rigidbody> ();
		if (Math.Abs(t.position.x - targetX) < 0.05 && Math.Abs(t.parent.position.z - targetY) < 0.05) {
			
			r.velocity = new Vector3 (0, r.velocity.y, 0);
			pr.velocity = new Vector3 (0, 0, 0);
			t.localPosition = new Vector3(targetX, t.position.y, 0);
			t.parent.position = new Vector3(0, 0, targetY);

			if (Input.GetAxis ("Horizontal") < 0) {
				beginMoveInDirection(3);
			} else if (Input.GetAxis ("Horizontal") > 0) {
				beginMoveInDirection(1);
			}

			if (Input.GetAxis ("Vertical") < 0) {
				beginMoveInDirection (2);
			} else if (Input.GetAxis ("Vertical") > 0) {
				beginMoveInDirection (0);
			}

		} else {
			if (t.position.x > targetX) {
				r.velocity = new Vector3 (-1f, 0, 0)*activeGoat.speed;
			} else if (t.position.x < targetX) {
				r.velocity = new Vector3 (1f, 0, 0)*activeGoat.speed;
			}
			if (t.parent.position.z > targetY) {
				r.velocity = new Vector3 (0, 0, -1f)*activeGoat.speed;
				pr.velocity = new Vector3 (0, 0, -1f)*activeGoat.speed;
			} else if (t.parent.position.z < targetY) {
				r.velocity = new Vector3 (0, 0, 1f)*activeGoat.speed;
				pr.velocity = new Vector3 (0, 0, 1f)*activeGoat.speed;
			}
		}

	}

	void beginMoveInDirection(int direction) {
		Debug.Log ("Moving in direction: " + direction);
		Transform t = this.GetComponent<Transform> ();
		t.localEulerAngles = new Vector3(0, direction*90, 0);
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

	void doCharSwitch() {

		int target = size;

		if (Input.GetButtonDown ("SwitchForward")) {
			target = (size + 1) % 3;
		}

		if (Input.GetButtonDown ("SwitchBackward")) {
			target = (size + 2) % 3;
		}

		if (target != size) {
			Debug.Log ("switching to size: " + target);
			switchTo (target);
		}
	}

	void switchTo(int size) {
		if (sizes [size]) {
			this.size = size;
			Transform t = this.GetComponent<Transform> ();
			foreach (GoatAttributes g in goats) {
				g.gameObject.SetActive (false);
			}
			activeGoat = goats [size];
			activeGoat.gameObject.SetActive (true);
		}

	}

	void dies() {

	}
}
