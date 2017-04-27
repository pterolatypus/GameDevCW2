using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class GoatAbility {

	public float cooldown { get; private set; }
	abstract public void use (int direction, PlayerController player);

}
