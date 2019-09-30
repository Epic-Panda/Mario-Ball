using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField]
	private float speed = 4;

	[SerializeField]
	private bool left = true;

	private bool falling;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (!DB.Database.GameEnd) {
			if (transform.position.y > -5.25) {
				// move to left
				if (!falling) {
					if (left)
						transform.position += Vector3.left * speed * Time.deltaTime;
					else
						transform.position += Vector3.right * speed * Time.deltaTime;
				}
			} else
				Destroy (this);
		}
	}

	private void OnCollisionExit2D(Collision2D collision){
		if (collision.gameObject.tag == "Platform") {
			falling = true;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Platform") {
			falling = false;
		}

		if (collision.gameObject.tag == "Player") {
			PlayerMovement.Player.RemoveLife ();
		}
	}
}
