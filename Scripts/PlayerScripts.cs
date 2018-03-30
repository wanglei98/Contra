using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour {

	// Use this for initialization
	public float moveSpeed;
	public float jumpHeight;
	public float gravity;
	public float jumpSpeed;

	private float fallHeight;
	private float jumproad;

	private float hsp;
	private float vsp;


	private bool mid;
	private bool isJump;
	private bool keyLeft;
	private bool keyRight;
	private bool keyUp;
	private bool keyDown;
	private bool keyJump;
	private bool keyAction;





	// Use this for initialization
	void Start()
	{
		mid = false;
		isJump = false;
		fallHeight = 0f;
		jumproad = 0f;
	}
		

	void getInput()
	{
		keyLeft = Input.GetKey(KeyCode.LeftArrow);
		keyRight = Input.GetKey(KeyCode.RightArrow);
		keyUp = Input.GetKey(KeyCode.UpArrow);
		keyDown = Input.GetKey(KeyCode.DownArrow);
		keyJump = Input.GetKey(KeyCode.Z);
		keyAction = Input.GetKey(KeyCode.X);
	}




	void move()
	{
		if (keyLeft)
			hsp = -moveSpeed * Time.deltaTime;
		if (keyRight) hsp = moveSpeed * Time.deltaTime;
		if ((!keyLeft && !keyRight) || (keyLeft && keyRight)) hsp = 0;
		if (vsp!=0f) 
			vsp = 0f;
		if (mid && keyUp) {
			vsp = 0.5f;
			mid = false;
		}
		if (!mid && keyDown) {
			vsp = -0.5f;
			mid = true;
		}
		if (keyUp && keyDown) {
			vsp = 0f;
			mid = false;
		}
		if (!isJump)
			transform.position = new Vector2 (transform.position.x + hsp, transform.position.y + vsp);
		else
			transform.position = new Vector2 (transform.position.x + hsp, transform.position.y);
	}

	void jump ()
	{
		if (keyJump && !isJump) {
			transform.position = new Vector2 (transform.position.x, transform.position.y + jumpSpeed * Time.deltaTime);
			jumproad += jumpSpeed * Time.deltaTime;
			if (jumproad >= jumpHeight) {
				isJump = true;
			}
		}
	}

	void fall ()
	{
		if (isJump) {
			transform.position = new Vector2 (transform.position.x, transform.position.y - gravity * Time.deltaTime);
			fallHeight += gravity * Time.deltaTime;
		}
		if ( fallHeight >= jumproad) {
			isJump = false;
			fallHeight = 0f;
			jumproad = 0f;
		}
	}



	void Update ()
	{
		getInput();
		jump ();
		move();
		fall ();
		if (keyAction) {
			WeaponScript weapon = GetComponent<WeaponScript> ();
			if (weapon != null) {

				weapon.Attack (false);
			}
		}
	}


	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.ToString ().IndexOf ("polpi") >= 0) {
			bool damagePlayer = false;

			EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript> ();
			if (enemy != null) {
				HealthScript enemyHealth = enemy.GetComponent<HealthScript> ();
				if (enemyHealth != null) {
					enemyHealth.Damage (enemyHealth.hp);
				}

				damagePlayer = true;
			}

			if (damagePlayer) {
				HealthScript playerHealth = this.GetComponent<HealthScript> ();
				if (playerHealth != null) {
					playerHealth.Damage (1);
				}
			}
		}
	}
}
