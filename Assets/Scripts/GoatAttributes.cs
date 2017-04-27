using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatAttributes : MonoBehaviour {

	public float speed = 1.0f;
	private GoatAbility ability;

	public void setAbility(GoatAbility ab) {
		this.ability = ab;
	}

	public void useAbility(int direction, PlayerController player) {
		if (ability != null) {
			ability.use (direction, player);
		}
	}

	public float abilityCooldown() {
		return ability.cooldown;
	}
}
