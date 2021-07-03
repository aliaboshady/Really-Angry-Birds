using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariables : MonoBehaviour {

	void Awake () {
		Ball.BallNumber = 0;
		Enemy.EnemiesAlive = 0;
	}
}
