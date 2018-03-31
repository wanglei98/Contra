using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

	private bool keyLeft;
	private bool keyRight;
	private bool keyUp;


	void getInput(){
		keyLeft = Input.GetKey(KeyCode.LeftArrow);
		keyRight = Input.GetKey(KeyCode.RightArrow);
		keyUp = Input.GetKey(KeyCode.UpArrow);
	}


	#region 

	/// <summary>
	/// zidan
	/// </summary>
	public Transform shotPrefab;

	public float shootingRate = 0.25f;

	private float shootCooldown;

	#endregion

	// Use this for initialization
	void Start () {
		shootCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (shootCooldown > 0) {
			shootCooldown -= Time.deltaTime;
		}
	}

	public bool CanAttack {
		get {
			return shootCooldown <= 0f;
		}
	}


	public void Attack (bool isEnemy)
	{
		if (CanAttack) {
			shootCooldown = shootingRate;

			var shotTransform = Instantiate (shotPrefab) as Transform;

			shotTransform.position = transform.position;

			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript> ();
			if (shot != null) {
				shot.isEnemyShot = isEnemy;
			}
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript> ();
			Move1Script move1 = shotTransform.gameObject.GetComponent<Move1Script> ();
			Move2Script move2 = shotTransform.gameObject.GetComponent<Move2Script> ();


			if (move != null) {

				if (shot.isEnemyShot)
				{
					move.direction.x = -1f;
					move.speed = new Vector2 (20,20);
				}
				else 
				{
					if (keyUp)
						move1.direction.y = 1f;
					if (keyRight)
						move.direction.x = 1f;
					if (keyLeft)
						move2.direction.x = 1f;
					move.speed = new Vector2 (10, 10);
				}
			}
		}
	}
}
