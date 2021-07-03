using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {
	public Rigidbody2D rb;
	public TrailRenderer trail;
	public Rigidbody2D hook;
	public GameObject nextBall;
	public float maxDistanceDrag = 2;
	public SpringJoint2D springJoint;
	public float getBallRate = 3;
	public float ballDieRate = 5;
	public static int BallNumber = 0;
	bool isPressed = false;
	bool isLetGo = false;
	bool canMove = true;

	void Start(){
		BallNumber++;
	}

	void Update(){
		if (isPressed && canMove) {
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (Vector2.Distance (mousePos, hook.position) > maxDistanceDrag) {
				rb.position = hook.position + (mousePos - hook.position).normalized * maxDistanceDrag;
			} 
			else {
				rb.position = mousePos;
			}
		}

		if (isLetGo && Vector2.Distance (gameObject.transform.position, hook.position) <= 1.3f) {
			springJoint.enabled = false;
			canMove = false;
			trail.enabled = true;
			if (nextBall!=null) {
				Invoke ("GetNextBall", getBallRate);
			}
			Invoke ("DestroyBall", ballDieRate);
		}
		if (Enemy.EnemiesAlive <= 0) {
			Invoke ("Restart", 2);
		}

		print ("Balls left: " + BallNumber);
	}

	void GetNextBall(){
		nextBall.SetActive (true);
	}

	void DestroyBall(){
		BallNumber--;
		Destroy (gameObject);
	}

	void OnMouseDown () {
		isPressed = true;
		rb.isKinematic = true;
	}

	void OnMouseUp () {
		isPressed = false;
		rb.isKinematic = false;
		if (Vector2.Distance(gameObject.transform.position, hook.position) > 1.3f) {
			isLetGo = true;
		}
	}

	void Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
