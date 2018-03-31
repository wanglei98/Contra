using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move1Script : MonoBehaviour {

	public Vector2 speed = new Vector2 (10, 10);

	public Vector2 direction = new Vector2 (0, 1);

	private Vector2 movement ;

	void Update ()
	{

		movement = new Vector2 (
			speed.x * direction.x,
			speed.y * direction.y);
	}

	void FixedUpdate ()
	{
		GetComponent<Rigidbody2D> ().velocity = movement;
	}

}
