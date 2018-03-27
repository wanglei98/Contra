using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour {

	// Use this for initialization
	public Vector2 speed = new Vector2(50,50);

	private Vector2 movement;

	void Update ()
	{
		bool shoot = Input.GetButtonDown ("Fire1");
		shoot |= Input.GetButtonDown ("Fire2");

		if (shoot) {
			WeaponScript weapon = GetComponent<WeaponScript> ();
			if (weapon != null) {

				weapon.Attack (false);
			}
		}

		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

		movement = new Vector2 (
			speed.x * inputX,
			speed.y * inputY);
		
	}

	void FixedUpdate()
	{
		GetComponent<Rigidbody2D> ().velocity = movement;
	}

}
