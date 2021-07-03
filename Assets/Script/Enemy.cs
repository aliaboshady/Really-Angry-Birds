using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {
	public float enemyDeathImpact = 5.5f;
	public GameObject deathEffect;
	public static int EnemiesAlive = 0;

	void Start(){
		EnemiesAlive++;
	}

	void Update(){
		if (Ball.BallNumber <= 0) {
			Invoke ("Restart", 2);
		}
		print ("Enemies left: " + EnemiesAlive);
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.relativeVelocity.magnitude >= enemyDeathImpact) {
			Instantiate (deathEffect, transform.position, Quaternion.identity);
			EnemiesAlive--;
			Destroy (gameObject);
		}
	}

	void Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}