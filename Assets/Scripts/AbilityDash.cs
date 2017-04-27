using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDash : GoatAbility {

	public float cooldown = 1f;

	public override void use(int direction, PlayerController player) {
		Transform t = player.GetComponent<Transform> ();
		Vector3 rot = t.localEulerAngles;
		switch (direction) {
			case 0:
				player.targetY += 2;
				break;
			case 1:
				player.targetX += 2;
				break;
			case 2:
				player.targetY -= 2;
				break;
			case 3:
				player.targetX -= 2;
				break;
		}
		if (direction % 2 == 1) {
			t.localEulerAngles = new Vector3 (0, direction * 90, 0);
			t.Translate (new Vector3 (0, 0, 2));
			t.localEulerAngles = rot;
		} else if (direction == 0) {
			t.parent.Translate (new Vector3 (0, 0, 2));
		} else {
			t.parent.Translate (new Vector3 (0, 0, -2));
		}
	}
}
